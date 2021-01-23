    _defaultView = CollectionViewSource.GetDefaultView(YourCollection);
    _defaultView.SortDescriptions.Add(new System.ComponentModel.SortDescription(".", System.ComponentModel.ListSortDirection.Ascending));
    _defaultView.Filter = o =>
    {
        int index = YourCollection.OrderBy(s => s).ToList().IndexOf(o as string);
        return index >= 0 && index < 10;
    };
    _defaultView.Refresh();
