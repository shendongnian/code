    private static T FindVisualChild<T>(DependencyObject item)
        where T : DependencyObject
    {
        var childCount = VisualTreeHelper.GetChildrenCount(item);
        var result = item as T;
        //the for-loop contains a null check; we stop when we find the result. 
        //so the stop condition for this method is embedded in the initialization
        //of the result variable.
        for (int i = 0; i < childCount && result == null; i++)
        {
            result = FindVisualChild<T>(VisualTreeHelper.GetChild(item, i));
        }
        return result;
    }
