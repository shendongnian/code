    public static ScrollViewer GetScrollViewer(this DependencyObject element)
    {
        if (element is ScrollViewer)
        {
            return (ScrollViewer)element;
        }
    
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
        {
            var child = VisualTreeHelper.GetChild(element, i);
    
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
