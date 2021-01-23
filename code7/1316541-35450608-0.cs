    ws.Columns.InsertEmpty(15, dataTable.Columns.Count);
    ws.InsertDataTable(dataTable, new InsertDataTableOptions()
    {
        ColumnHeaders = true,
        StartRow = 0,
        StartColumn = 15
    });
