    private ListSortDirection lastSortDirection;
    private string lastSortMemberPath;
    public async void Sorting(DataGridSortingEventArgs e)
    {
        e.Handled = true;
        if (e.Column.SortMemberPath == lastSortMemberPath)
        {
            if (lastSortDirection == ListSortDirection.Ascending)
                e.Column.SortDirection = ListSortDirection.Descending;
            else
                e.Column.SortDirection = ListSortDirection.Ascending;
        }
        else
            e.Column.SortDirection = ListSortDirection.Ascending;
        string dir = (e.Column.SortDirection == ListSortDirection.Ascending) ? "ASC" : "DESC";
        lastSortDirection = e.Column.SortDirection;
        lastSortMemberPath = e.Column.SortMemberPath;
        await UpdateData(e.Column.SortMemberPath, dir);
    
        // In my opinion, this last bit is redundant since data should come already sorted
        CollectionView.SortDescriptions.Clear();
        CollectionView.SortDescriptions.Add(new SortDescription(e.Column.SortMemberPath, e.Column.SortDirection));
    }
