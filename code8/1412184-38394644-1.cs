    foreach (DataGridColumn column in columns)
    {
        DataGridTextColumn col = new DataGridTextColumn() ;
        col.Binding = ((DataGridTextColumn)column).Binding;
        col.Header = column.Header;
        dataGrid.Columns.Add(col);
    }
