        public static FrameworkElement GetControlByName(DependencyObject parent, string name)
        {
            int count = VisualTreeHelper.GetChildrenCount(parent);
            for (var i = 0; i < count; ++i)
            {
                var child = VisualTreeHelper.GetChild(parent, i) as FrameworkElement;
                if (child != null)
                {
                    if (child.Name == name)
                    {
                        return child;
                    }
                    var descendantFromName = GetControlByName(child, name);
                    if (descendantFromName != null)
                    {
                        return descendantFromName;
                    }
                }
            }
            return null;
        }
