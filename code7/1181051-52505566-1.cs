    // Hold ScrollViwer
    public ScrollViewer listScrollviewer = new ScrollViewer();
   
    // Binded event, which will trigger on scrolling of ScrollViewer
    private void ContentCommentScroll_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
    {
        Scrolling(ContentCommentScroll);
    }
    
    private void Scrolling(DependencyObject depObj)
    {
        ScrollViewer myScroll= GetScrollViewer(depObj);
        // Detecting if ScrollViewer is fully vertically scrolled or not
        if (myScroll.VerticalOffset ==  myScroll.ScrollableHeight)
        {
            // ListView reached at of its end, when you are scrolling it vertically.
            // Do your work here here 
        }
    }
    public static ScrollViewer GetScrollViewer(DependencyObject depObj)
    {
        if (depObj is ScrollViewer) return depObj as ScrollViewer;
    
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
        {
            var child = VisualTreeHelper.GetChild(depObj, i);
    
            var result = GetScrollViewer(child);
            if (result != null) return result;
        }
        return null;
    }
