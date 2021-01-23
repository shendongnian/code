    public static void ScrollToIndex(this ListViewBase listViewBase, int index)
    {
        bool isVerticalScrolling;
    
        // if it's a ListView, then we assume the scrolling is vertical
        if (listViewBase is ListView)
        {
            isVerticalScrolling = true;
        }
        // if it's a GridView, then we assume the scrolling is horizontal
        else if (listViewBase is GridView)
        {
            isVerticalScrolling = false;
        }
        else
        {
            throw new ArgumentException("The control needs to inherit from ListViewBase!");
        }
    
        // get the ScrollViewer withtin the ListView/GridView
        var scrollViewer = listViewBase.GetScrollViewer();
        // get the SelectorItem to scroll to
        var selectorItem = (SelectorItem)listViewBase.ContainerFromIndex(index);
    
        // calculate the position object in order to know how much to scroll to
        var transform = selectorItem.TransformToVisual((UIElement)scrollViewer.Content);
        var position = transform.TransformPoint(new Point(0, 0));
    
        // do the scrolling
        if (isVerticalScrolling)
        {
            scrollViewer.ChangeView(null, position.Y, null);
        }
        else
        {
            scrollViewer.ChangeView(position.X, null, null);
        }
    }
    
    public static void ScrollToItem(this ListViewBase listViewBase, object item)
    {
        bool isVerticalScrolling;
    
        // if it's a ListView, then we assume the scrolling is vertical
        if (listViewBase is ListView)
        {
            isVerticalScrolling = true;
        }
        // if it's a GridView, then we assume the scrolling is horizontal
        else if (listViewBase is GridView)
        {
            isVerticalScrolling = false;
        }
        else
        {
            throw new ArgumentException("The control needs to inherit from ListViewBase!");
        }
    
        // get the ScrollViewer withtin the ListView/GridView
        var scrollViewer = listViewBase.GetScrollViewer();
        // get the SelectorItem to scroll to
        var selectorItem = (SelectorItem)listViewBase.ContainerFromItem(item);
    
        // calculate the position object in order to know how much to scroll to
        var transform = selectorItem.TransformToVisual((UIElement)scrollViewer.Content);
        var position = transform.TransformPoint(new Point(0, 0));
    
        // do the scrolling
        if (isVerticalScrolling)
        {
            scrollViewer.ChangeView(null, position.Y, null);
        }
        else
        {
            scrollViewer.ChangeView(position.X, null, null);
        }
    }
