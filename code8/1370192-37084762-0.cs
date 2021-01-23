    foreach(var fvi in carrousel.Items)
    {
    FlipViewItem item=carrousel.ContainerFromItem(fvi);
    var rectangle =FindElementInVisualTree<Rectangle>(item);
    
    
    
    //Or without VisualTreeHelper you can do like what were you trying before 
    Rectangle g = (item.Content as Grid).FindName("profile") as Rectangle;
    g.Width = double;
    g.Height = double;
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
