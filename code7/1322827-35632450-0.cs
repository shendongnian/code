    var rows = dataTable.AsEnumerable()
        .Where(row => row.Field<int>("ID") == id);    // a LINQ query
    var columnsWithoutValues =  dataTable.Columns.Cast<DataColumn>()
        .Where(col => rows.All(r => r.IsNull(col)));  // columns without values
    DataTable tblResult = dataTable.Clone(); // same columns no data
    foreach (DataColumn colToRemove in columnsWithoutValues)
        tblResult.Columns.Remove(colToRemove.ColumnName); // remove columns without data
    foreach (DataRow row in rows)
    {
        DataRow newRow = tblResult.Rows.Add();
        foreach (DataColumn col in tblResult.Columns)
            newRow[col] = row[col.ColumnName];  // copy the values into the target table
    }
