    private void AddRow(int id, string name, string age)
    {
        var runtimeSource = gridControl.DataSource as DataTable;
    
        DataRow dRow = runtimeSource.NewRow();
        dRow.ItemArray = new object[] { id, name, age };
    
        runtimeSource.Rows.Add(dRow);
    
        gridControl.RefreshDataSource();
    }
