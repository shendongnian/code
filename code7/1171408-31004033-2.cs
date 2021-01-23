    string[] keyColumnNames = { "Col2", "Col3" };
    DataColumn[] childColumns = dtChild.Columns.Cast<DataColumn>() 
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
        string col2 = null;
        string col3 = null;
        if (firstMatchingRow != null)
        {
            col2 = firstMatchingRow.Field<string>("Col2");
            col3 = firstMatchingRow.Field<string>("Col3");
        }
        newRow.SetField("Col2", col2);
        newRow.SetField("Col3", col3);
    }
