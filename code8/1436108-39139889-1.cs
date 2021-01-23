    private void myListView_Loaded(object sender, RoutedEventArgs e)
    {
        var itemstackpanel = FindChildOfType<ItemsStackPanel>(myListView);
        if (itemstackpanel != null)
            itemstackpanel.Orientation = Orientation.Horizontal;
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
 
