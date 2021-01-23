    DataTable pivotedTable = table.Clone(); // same columns, empty
    var pivotColumns = pivotedTable.Columns.Cast<DataColumn>().Skip(1).ToList(); 
    var dateGroups = table.AsEnumerable()
        .GroupBy(r => r.Field<DateTime>("Date").Date);
    foreach(var date in dateGroups)
    {
        DataRow row = pivotedTable.Rows.Add(); // already added to table now
        row.SetField("Date", date.Key);
        foreach(DataColumn c in pivotColumns)
            row.SetField(c, date.Sum(r => r.Field<int>(c.ColumnName)));
    }
