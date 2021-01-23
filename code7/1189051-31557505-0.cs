    sbc.ColumnMappings.Clear();
    int i = hasTableIdentity ? 1 : 0;
    DataColumn dc;
    foreach (Tables.BulkColumn bc in columns)
    {
        dc = new DataColumn();
        dc.DataType = bc.ColumnValueType;
        dc.ColumnName = bc.Name;
        dc.Unique = false;
        sbc.ColumnMappings.Add(dc.ColumnName, i);
        actualDataTable.Columns.Add(dc);
        i++;
    }
