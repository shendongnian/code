    public static T GetVisualChild<T>(Visual parent) where T : Visual
    {
        Visual visual;
        T child = default(T);
    
        int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
        for (int i = 0; i < childrenCount; i++)
        {
            visual = (Visual)VisualTreeHelper.GetChild(parent, i);
            child = visual as T;
            if (child == null)
            {
                child = GetVisualChild<T>(visual);
            }
            if (child != null)
            {
                break;
            }
        }
        return child;
    }
    
    public T FindVisualChild<T>(DependencyObject obj, string name) where T : DependencyObject
    {
        DependencyObject child;
        FrameworkElement frameworkElement;
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
        {
            child = VisualTreeHelper.GetChild(obj, i);
            frameworkElement = child as FrameworkElement;
            if (child != null && child is T && frameworkElement != null && frameworkElement.Name == name)
            {
                return (T)child;
            }
            else
            {
                T childOfChild = FindVisualChild<T>(child, name);
                if (childOfChild != null)
                {
                    return childOfChild;
                }
            }
        }
    
        return null;
    }
