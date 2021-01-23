    UIElement previous = null;
    private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (previous != null) previous.Visibility = Visibility.Collapsed;
        if (e.AddedItems.Any())
        {
            var container = (sender as ListView).ContainerFromItem(e.AddedItems.First());
            (previous = Child<Rectangle>(container, "DetailArea")).Visibility = Visibility.Visible;
        }
    }
    public T Child<T>(DependencyObject parent, string name) where T : FrameworkElement
    {
        return Children(parent).OfType<T>().FirstOrDefault(x => x.Name == name);
    }
    public List<DependencyObject> Children(DependencyObject parent)
    {
        var list = new List<DependencyObject>();
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
        {
            var child = VisualTreeHelper.GetChild(parent, i) as DependencyObject;
            if (child != null)
            {
                list.Add(child);
                list.AddRange(Children(child));
            }
        }
        return list;
    }
