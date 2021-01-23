    DataRow firstRow = table.NewRow();
    for (var i = 0; i < table.Columns.Count; i++)
    {
        DataColumn col = table.Columns[i];
        if (col.DataType == typeof(string))
        {
            firstRow.SetField(i, col.ColumnName);
        }
        else if (col.DataType == typeof(DateTime))
        {
            DateTime dt;
            if (DateTime.TryParse(col.ColumnName, out dt))
                firstRow.SetField(i, dt);
        }
        else if (col.DataType == typeof(double))
        {
            double d;
            if (double.TryParse(col.ColumnName, out d))
                firstRow.SetField(i, d);
        }
    }
    table.Rows.InsertAt(firstRow, 0);
