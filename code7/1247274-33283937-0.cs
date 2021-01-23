    var locationColumns = table.Columns.Cast<DataColumn>()
        .Where(c => c.ColumnName.StartsWith("Location", StringComparison.InvariantCultureIgnoreCase))
        .ToList();
    var dateGroups = table.AsEnumerable()
        .GroupBy(r => r.Field<DateTime>("Date").Date);
    foreach(var date in dateGroups)
    {
        var locationCounts = locationColumns
            .Select(c => new { Column = c, Count = date.Sum(r => r.Field<int>(c)) });
        foreach(var locCount in locationCounts)
        {
            DataRow row = pivotedTable.Rows.Add(); // already added to table now
            row.SetField("Date", date.Key);
            row.SetField("Count", locCount.Count);
            row.SetField("Location", locCount.Column.ColumnName);
        }
    }
