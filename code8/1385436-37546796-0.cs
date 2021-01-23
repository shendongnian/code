        public class ComboBoxBehave
        {
    
            public static string GetApplyTag(DependencyObject obj)
            {
                return (string)obj.GetValue(ApplyTagProperty);
            }
    
            public static void SetApplyTag(DependencyObject obj, string value)
            {
                obj.SetValue(ApplyTagProperty, value);
            }
    
            // Using a DependencyProperty as the backing store for ApplyTag.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty ApplyTagProperty =
                DependencyProperty.RegisterAttached("ApplyTag", typeof(string), typeof(ComboBoxBehave), new UIPropertyMetadata(null, ApplyTagChanged));
    
    
            private static void ApplyTagChanged(DependencyObject DO, DependencyPropertyChangedEventArgs e)
            {
                var combo = DO as ComboBox;
                if (combo != null)
                {
                    combo.Loaded += new RoutedEventHandler(combo_Loaded);
                }
            }
    
            static void combo_Loaded(object sender, RoutedEventArgs e)
            {
                var combo = sender as ComboBox;
                if (combo != null)
                {
                    var text = FindChild<TextBox>(sender as DependencyObject, "PART_EditableTextBox");
                    if (text != null)
                    {
                        text.Tag = GetApplyTag(combo);
                    }
                }
            }
    
            public static T FindChild<T>(DependencyObject parent, string childName)
      where T : DependencyObject
            {
                // Confirm parent and childName are valid. 
                if (parent == null) return null;
    
                T foundChild = null;
    
                int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
                for (int i = 0; i < childrenCount; i++)
                {
                    var child = VisualTreeHelper.GetChild(parent, i);
                    // If the child is not of the request child type child
                    T childType = child as T;
                    if (childType == null)
                    {
                        // recursively drill down the tree
                        foundChild = FindChild<T>(child, childName);
    
                        // If the child is found, break so we do not overwrite the found child. 
                        if (foundChild != null) break;
                    }
                    else if (!string.IsNullOrEmpty(childName))
                    {
                        var frameworkElement = child as FrameworkElement;
                        // If the child's name is set for search
                        if (frameworkElement != null && frameworkElement.Name == childName)
                        {
                            // if the child's name is of the request name
                            foundChild = (T)child;
                            break;
                        }
                    }
                    else
                    {
                        // child element found.
                        foundChild = (T)child;
                        break;
                    }
                }
    
                return foundChild;
            }
        }
