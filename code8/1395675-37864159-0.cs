    List<DataRow> RowList = new List<DataRow>();
    foreach (DataRow row in importSetOfTables.Tables["MyTable"].Rows)
    {
        // Use LINQ to get a list of rows matching on ID
        List<DataRow> matches = (from t in importSetOfTables.Tables["MyTable"].Rows
                                 where row.ID == t.ID
                                 select a).ToList();
        // Insert matching rows into your collection
        if (!matches.Count() > 0)
             RowList.AddRange(matches);
    }
