    public static T FindControl<T>(UIElement parent, Type targetType, string ControlName) where T : FrameworkElement
    {
     
        if (parent == null) return null;
     
        if (parent.GetType() == targetType && ((T)parent).Name == ControlName)
        {
            return (T)parent;
        }
        T result = null;
        int count = VisualTreeHelper.GetChildrenCount(parent);
        for (int i = 0; i < count; i++)
        {
            UIElement child = (UIElement)VisualTreeHelper.GetChild(parent, i);
     
            if (FindControl<T>(child, targetType, ControlName) != null)
            {
                result = FindControl<T>(child, targetType, ControlName);
                break;
            }
        }
        return result;
    }
