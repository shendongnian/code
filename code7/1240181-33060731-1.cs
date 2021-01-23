    for (var i = 0; i < insertAtIndexes.Count; i++)
    {
        var emptyRow = dataTable.NewRow();
        dataTable.Rows.InsertAt(SetDefaultValues(emptyRow), insertAtIndexes[i] + i);
    }
    
    static DataRow SetDefaultValues(DataRow row)
    {
        row.SetField(1, 0);
        row.SetField(2, 0);
        row.SetField(3, 0);
        row.SetField(4, 0);
        return row;
    }
