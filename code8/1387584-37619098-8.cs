    //foreach (var obj in _selector.Items)
    //{
    //    ListBoxItem item = _selector.ItemContainerGenerator.ContainerFromItem(obj) as ListBoxItem;
    for (int i=0; i<_selector.Items.Count; i++)
    {
        ListBoxItem item =_selector.ItemContainerGenerator.ContainerFromIndex(i) as ListBoxItem;
        if (item != null)
        {
            Point point = item.TransformToAncestor(AdornedElement).Transform(new Point(0, 0));
            Rect bandrect = new Rect(startpoint, currentpoint);
            Rect elementrect = new Rect(point.X, point.Y, item.ActualWidth, item.ActualHeight);
            if (bandrect.IntersectsWith(elementrect))
            {
                item.IsSelected = true;
            }
            else
            {
                item.IsSelected = false;
            }
        }
    }
