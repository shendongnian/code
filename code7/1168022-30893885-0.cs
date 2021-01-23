    void SortHandler(object sender, DataGridSortingEventArgs e)
    {
        var collectionViewSource = (sender as DataGrid).ItemsSource as CollectionViewSource;
    
        var propertyName = e.Column.SortMemberPath;
        var sortDirection = ListSortDirection.Ascending;
    
        foreach (var sortDescription in collectionViewSource.SortDescriptions)
            if (sortDescription.PropertyName == propertyName &&
                sortDescription.Direction == ListSortDirection.Ascending)
            {
                sortDirection = ListSortDirection.Descending;
                break;
            }
    
        var sortDescription = new SortDescription()
        {
            PropertyName = propertyName,
            Direction = sortDirection
        };
    
        collectionViewSource.SortDescriptions.Clear();
        collectionViewSource.SortDescriptions.Add(sortDescription);
    }
