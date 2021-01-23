    ScrollViewer scrollViewer = GetScrollViewer(MyListView);
    public static ScrollViewer GetScrollViewer(DependencyObject depObj)
    {
        var obj = depObj as ScrollViewer;
        if (obj != null) return obj;
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
        {
            var child = VisualTreeHelper.GetChild(depObj, i);
            var result = GetScrollViewer(child);
            if (result != null) return result;
        }
        return null;
    }
