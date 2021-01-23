    foreach (DataGridColumn column in columns)
    {
        DataGridTextColumn col = new DataGridTextColumn() ;
        col.Binding = ((DataGridTextColumn)column).Binding;
        dataGrid.Columns.Add(col);
    }
