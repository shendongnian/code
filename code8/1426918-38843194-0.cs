    private void FeaturedList_Loaded(object sender, RoutedEventArgs e)
    {
        var FeaturedListscrollViewer = FindChildOfType<ScrollViewer>(FeaturedList);
        if (FeaturedListscrollViewer != null)
            FeaturedListscrollViewer.ViewChanged += scrollViewer_ViewChanged;
    }
    
    private void FeaturedAlbumsList_Loaded(object sender, RoutedEventArgs e)
    {
        var FeaturedAlbumsListscrollViewer = FindChildOfType<ScrollViewer>(FeaturedAlbumsList);
        if (FeaturedAlbumsListscrollViewer != null)
            FeaturedAlbumsListscrollViewer.ViewChanged += scrollViewer_ViewChanged;
    }
    
    private void scrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
    {
        if (e.IsIntermediate)
            rtPanel.Visibility = Visibility.Collapsed;
        else
            rtPanel.Visibility = Visibility.Visible;
    }
    
    public static T FindChildOfType<T>(DependencyObject root) where T : class
    {
        var queue = new Queue<DependencyObject>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            DependencyObject current = queue.Dequeue();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(current); i++)
            {
                var child = VisualTreeHelper.GetChild(current, i);
                var typedChild = child as T;
                if (typedChild != null)
                {
                    return typedChild;
                }
                queue.Enqueue(child);
            }
        }
        return null;
    }
