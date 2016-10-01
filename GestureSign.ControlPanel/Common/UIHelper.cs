﻿using System;
using System.Windows;
using System.Windows.Media;
using MahApps.Metro.Controls;

namespace GestureSign.ControlPanel.Common
{
    class UIHelper
    {
        public static MetroWindow GetParentWindow(DependencyObject dependencyObject)
        {
            return Window.GetWindow(dependencyObject) as MetroWindow;

        }

        public static ResourceDictionary GetSystemAccent()
        {
            SolidColorBrush AccentBaseColorBrush = (SolidColorBrush)SystemParameters.WindowGlassBrush;
            Double dY = AccentBaseColorBrush.Color.R * 0.299 + AccentBaseColorBrush.Color.G * 0.587 + AccentBaseColorBrush.Color.B * 0.114;
            if (dY >= 192 || dY < 50)
            {
                return null;
            }
            ResourceDictionary rd = new ResourceDictionary();

            Color AccentBaseColor = AccentBaseColorBrush.Color;

            Color HighlightColor = Color.Multiply(AccentBaseColor, 0.73f);
            HighlightColor.A = 0xFF;
            SolidColorBrush HighlightBrush = new SolidColorBrush(HighlightColor);

            Color AccentColor = AccentBaseColor;
            AccentColor.A = 0xCC;
            SolidColorBrush AccentColorBrush = new SolidColorBrush(AccentColor);

            Color AccentColor2 = AccentBaseColor;
            AccentColor2.A = 0x99;
            SolidColorBrush AccentColorBrush2 = new SolidColorBrush(AccentColor2);

            Color AccentColor3 = AccentBaseColor;
            AccentColor3.A = 0x66;
            SolidColorBrush AccentColorBrush3 = new SolidColorBrush(AccentColor3);

            Color AccentColor4 = AccentBaseColor;
            AccentColor4.A = 0x33;
            SolidColorBrush AccentColorBrush4 = new SolidColorBrush(AccentColor4);
            //Color AccentColor= HighlightColor,
            rd.Add("HighlightColor", HighlightColor);
            rd.Add("AccentBaseColor", AccentBaseColor);
            rd.Add("AccentColor", AccentColor);
            rd.Add("AccentColor2", AccentColor2);
            rd.Add("AccentColor3", AccentColor3);
            rd.Add("AccentColor4", AccentColor4);

            rd.Add("HighlightBrush", HighlightBrush);
            rd.Add("AccentBaseColorBrush", AccentBaseColorBrush);
            rd.Add("AccentColorBrush", AccentColorBrush);
            rd.Add("AccentColorBrush2", AccentColorBrush2);
            rd.Add("AccentColorBrush3", AccentColorBrush3);
            rd.Add("AccentColorBrush4", AccentColorBrush4);

            rd.Add("WindowTitleColorBrush", AccentColorBrush);
            rd.Add("AccentSelectedColorBrush", Brushes.White);

            rd.Add("IdealForegroundColor", Colors.White);
            rd.Add("IdealForegroundColorBrush", Brushes.White);

            rd.Add("CheckmarkFill", AccentColorBrush);
            rd.Add("RightArrowFill", AccentColorBrush);
            return rd;
        }

        public static T GetParentDependencyObject<T>(DependencyObject dependencyObject) where T : DependencyObject
        {

            DependencyObject parent = VisualTreeHelper.GetParent(dependencyObject);
            while (parent != null)
            {
                if (parent is T)
                {
                    return (T)parent;
                }
                parent = VisualTreeHelper.GetParent(parent);
            }
            return null;
        }

        public static TChildItem FindVisualChild<TChildItem>(DependencyObject obj) where TChildItem : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                var item = child as TChildItem;
                if (item != null)
                    return item;
                else
                {
                    TChildItem childOfChild = FindVisualChild<TChildItem>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }
    }
}
