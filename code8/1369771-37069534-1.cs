     private void mainContentPivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        PivotItem item = (sender as Pivot).ContainerFromItem((sender as Pivot).SelectedItem) as PivotItem;
        var gridView =    FindElementInVisualTree<GridView>(item);
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
