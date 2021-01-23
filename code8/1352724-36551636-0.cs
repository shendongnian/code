       private void Remove_Click(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem mfi = (MenuFlyoutItem)sender;
            var datacontext = mfi.DataContext;
            GridViewItem item = grd.ContainerFromItem(datacontext) as GridViewItem ;
            Button button = FindElementInVisualTree<Button>(item);
        }
     private T FindElementInVisualTree<T>(DependencyObject parentElement) where T : DependencyObject
            {
                var count = VisualTreeHelper.GetChildrenCount(parentElement);
                if (count == 0) return null;
    
                for (int i = 0; i < count; i++)
                {
                    var child = VisualTreeHelper.GetChild(parentElement, i);
                    if (child != null && child is T)
                        return (T)child;
                    else
                    {
                        var result = FindElementInVisualTree<T>(child);
                        if (result != null)
                            return result;
                    }
                }
                return null;
            }
