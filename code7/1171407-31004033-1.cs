    DataTable dtResult = dtChild.Clone();
    foreach(DataRow row in dtChild.Rows)
    {
        DataRow newRow = dtResult.Rows.Add();
        newRow.SetField("Col1", row.Field<string>("Col1"));
        DataRow firstmatchingRow = dtMaster.AsEnumerable()
            .FirstOrDefault(r => r.Field<string>("Col2") == row.Field<string>("Col2")
                              && r.Field<string>("Col3") == row.Field<string>("Col3"));
        string col2 = null;
        string col3 = null;
        if(firstmatchingRow != null)
        {
            col2 = firstmatchingRow.Field<string>("Col2");
            col3 = firstmatchingRow.Field<string>("Col3");
        }
        newRow.SetField("Col2", col2);
        newRow.SetField("Col3", col3);
    }
