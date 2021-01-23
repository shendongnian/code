    private static ScrollViewer GetScrollbar(DependencyObject dep)
    {
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(dep); i++)
        {
            var child = VisualTreeHelper.GetChild(dep, i);
            if (child != null && child is ScrollViewer)
                return child as ScrollViewer;
            else
            {
                ScrollViewer sub = GetScrollbar(child);
                if (sub != null)
                    return sub;
            }
        }
        return null;
    }
     
    ScrollViewer scrollView = GetScrollbar(myDataGrid);
