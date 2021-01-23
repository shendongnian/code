    public static class UIHelper
    {        
        public static DependencyObject FindChild(DependencyObject parent, string name)
        {
            // confirm parent and name are valid.
            if (parent == null || string.IsNullOrEmpty(name)) return null;
            if (parent is FrameworkElement && (parent as FrameworkElement).Name == name) return parent;
            DependencyObject result = null;
            if (parent is FrameworkElement) (parent as FrameworkElement).ApplyTemplate();
            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                result = FindChild(child, name);
                if (result != null) break;
            }
            return result;
        }
    }
