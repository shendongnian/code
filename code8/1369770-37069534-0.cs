     private void mainContentPivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        var gridView =    FindElementInVisualTree<GridView>(sender as PivotItem);
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
