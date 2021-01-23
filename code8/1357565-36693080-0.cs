    public ScrollViewer GetScrollViewer(DependencyObject o)
    {
        if (o is ScrollViewer)
        {
            return o as ScrollViewer;
        }
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(o); i++)
        {
            var child = VisualTreeHelper.GetChild(o, i);
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
