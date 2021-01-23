    private void dataGrid1_CellDoubleClick(object sender, RoutedEventArgs e)
    {
        var cell = sender as DataGridCell;
        if (cell != null)
        {
            (this.DataContext as MyViewModel).DoStuff(cell.DataContext, cell.Column.SortMemberPath);
        }
    }
