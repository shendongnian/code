    string[] keyColumnNames = { "Col2", "Col3" };
    DataTable dtResult = dtChild.Clone();
    DataColumn[] childColumns = dtResult.Columns.Cast<DataColumn>() 
        .Where(c => keyColumnNames.Contains(c.ColumnName)) 
        .ToArray();
    DataColumn[] masterColumns = dtMaster.Columns.Cast<DataColumn>() 
        .Where(c => keyColumnNames.Contains(c.ColumnName)) 
        .ToArray();
    foreach (DataRow row in dtChild.Rows)
    {
        DataRow newRow = dtResult.Rows.Add();
        newRow.SetField("Col1", row.Field<string>("Col1"));
        var matchingRows = dtMaster.AsEnumerable()
            .Where(masterRow => !masterColumns.Select(mc => masterRow.Field<string>(mc))
                .Except(childColumns.Select(cc => row.Field<string>(cc)))
                .Any());
        DataRow firstMatchingRow = matchingRows.FirstOrDefault();
        foreach(DataColumn col in childColumns)
            newRow.SetField(col, firstMatchingRow == null 
                ? null 
                : firstMatchingRow.Field<string>(col.ColumnName));
    }
