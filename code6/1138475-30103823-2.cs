    var val = this.MyList.Items.IndexOf(myObj);
    if (val != -1)
    {
        ScrollViewer scrollViewer = GetScrollViewer(MyList) as ScrollViewer;
        var itemHeight = scrollViewer.ExtentHeight / this.MyList.Items.Count;
        scrollViewer.ScrollToVerticalOffset(itemHeight * val);
    }
    //where
    public static DependencyObject GetScrollViewer(DependencyObject o)
    {
        if (o is ScrollViewer)
        { return o; }
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(o); i++)
        {
            var child = VisualTreeHelper.GetChild(o, i);
            var result = GetScrollViewer(child);
            if (result == null)
            {
                continue;
            }
            else
            {
                return result;
            }
        }
        return null;
    }
