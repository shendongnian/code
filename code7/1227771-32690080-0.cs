    foreach (DataTable table in ds.Tables)
    {
        List<DataColumn> stringColumns = table.Columns.Cast<DataColumn>()
            .Where(c => c.DataType == typeof(string))
            .ToList();
        var columnsAllNotAvailable = stringColumns
            .Where(c => table.AsEnumerable()
                .All(r =>  String.Equals(r.Field<string>(c), "NA", StringComparison.InvariantCultureIgnoreCase)));
        foreach(DataColumn col in columnsAllNotAvailable)
            table.Columns.Remove(col);
    }
