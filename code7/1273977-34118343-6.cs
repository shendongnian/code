    public T FindDescendant<T>(DependencyObject obj) where T : DependencyObject
    {
        if (obj is T)
            return obj as T;
        int childrenCount = VisualTreeHelper.GetChildrenCount(obj);
        if (childrenCount < 1)
            return null;
        for (int i = 0; i < childrenCount; i++)
        {
            DependencyObject child = VisualTreeHelper.GetChild(obj, i);
            if (child is T)
                return child as T;
        }
        for (int i = 0; i < childrenCount; i++)
        {
            DependencyObject child = FindDescendant<T>(VisualTreeHelper.GetChild(obj, i));
            if (child != null && child is T)
                return child as T;
        }
        return null;
    }
