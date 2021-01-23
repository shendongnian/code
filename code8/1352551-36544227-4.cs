    public static DataTable GridToDataTable(DataGrid dataGrid)
    {
        DataView dView = (DataView)dataGrid.ItemsSource)
        DataTable table= dView.Table.Clone();
        foreach (DataRowView dv in dView )
           dt.ImportRow(dView .Row);
        return table;
    }
