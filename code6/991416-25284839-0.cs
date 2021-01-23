    var border = VisualTreeHelper.GetChild(listView, 0) as Border;
    if (border != null)
    {
        var scrollviewer = border.Child as ScrollViewer;
        if (scrollviewer != null)
        {
            scrollviewer.ViewChanged += Scrollviewer_ViewChanged;
            scrollviewer.ViewChanging += ScrollviewerOnViewChanging;
        }
    }
    private void ScrollviewerOnViewChanging(object sender, ScrollViewerViewChangingEventArgs scrollViewerViewChangingEventArgs)
    {
        Debug.WriteLine("changing:{0}", ((ScrollViewer)sender).VerticalOffset);
    }
    void Scrollviewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
    {
        Debug.WriteLine("ViewChanged:{0}", ((ScrollViewer)sender).VerticalOffset);
    }
