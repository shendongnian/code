    public static UIElement FindVisualParent(this UIElement element, Type type) 
    {
        UIElement parent = element;
        while (parent != null)
        {
            if (type.IsAssignableFrom(parent.GetType()))
            {
                return parent;
            }
            parent = VisualTreeHelper.GetParent(parent) as UIElement;
        }
        return null;
    }
