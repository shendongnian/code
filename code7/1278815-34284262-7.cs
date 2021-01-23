    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Media;
    
    namespace WpfApplication2
    {
        internal static class UIHelper
        {
            internal static IList<T> FindChildren<T>(DependencyObject element) where T : FrameworkElement
            {
                List<T> retval = new List<T>();
                for (int counter = 0; counter < VisualTreeHelper.GetChildrenCount(element); counter++)
                {
                    FrameworkElement toadd = VisualTreeHelper.GetChild(element, counter) as FrameworkElement;
                    if (toadd != null)
                    {
                        T correctlyTyped = toadd as T;
                        if (correctlyTyped != null)
                        {
                            retval.Add(correctlyTyped);
                        }
                        else
                        {
                            retval.AddRange(FindChildren<T>(toadd));
                        }
                    }
                }
                return retval;
            }
    
            internal static T FindParent<T>(DependencyObject element) where T : FrameworkElement
            {
                FrameworkElement parent = VisualTreeHelper.GetParent(element) as FrameworkElement;
                while (parent != null)
                {
                    T correctlyTyped = parent as T;
                    if (correctlyTyped != null)
                    {
                        return correctlyTyped;
                    }
                    return FindParent<T>(parent);
                }
                return null;
            }
        }
    }
