    int index = 0;
    foreach (var col in
        MyDataTable.Columns
        .Cast<DataColumn>()
        .OrderBy(x => tableColumns.IndexOf(x.ColumnName))
        .ToList())
    {
        col.SetOrdinal(index);
        index ++;
    }
