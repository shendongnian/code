    var tblAccCounts = new DataTable();
    tblAccCounts.Columns.Add("Account#");
    tblAccCounts.Columns.Add("Count", typeof(int));
    foreach(var grp in accountGroups)
        tblAccCounts.Rows.Add(grp.Account, grp.Count);
