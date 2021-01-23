    private void DataGrid_OnSorting(object sender, DataGridSortingEventArgs e)
    {
        var sortedGrid = sender as DataGrid;
        foreach (var item in sortedGrid.Items)
        {
            DataGridItems.Add(item);
        }
    }
