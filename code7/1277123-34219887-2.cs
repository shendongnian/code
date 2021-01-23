    DataRow firstRow = table.NewRow();
    for (var i = 0; i < table.Columns.Count; i++)
    {
        string colName = table.Columns[i].ColumnName;
        DateTime dt;
        double d;
        if(DateTime.TryParse(colName, out dt))
            firstRow.SetField(i, dt.ToOADate());
        else if(double.TryParse(colName, out d))
            firstRow.SetField(i, d);
    }
    table.Rows.InsertAt(firstRow, 0);
