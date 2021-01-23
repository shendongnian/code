    public static class FrameworkElementExtensions
    {
            public static T TraverseCTFindShape<T>(DependencyObject root, String name) where T : Windows.UI.Xaml.Shapes.Shape
            {
                T control = null;
    
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(root); i++)
                {
                    var child = VisualTreeHelper.GetChild(root, i);
    
                    string childName = child.GetValue(FrameworkElement.NameProperty) as string;
                    control = child as T;
    
                    if (childName == name)
                    {
                        return control;
                    }
                    else
                    {
                        control = TraverseCTFindShape<T>(child, name);
    
                        if (control != null)
                        {
                            return control;
                        }
                    }
                }
    
                return control;
            }
    }
