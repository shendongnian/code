    //Include Two Empty Rows After Each WCG
    var insertAtIndexes = ds.Tables["Capacity Progress to Due Date"].Rows.Cast<DataRow>()
    //.GroupBy(row => new { wcg = row.Field<int>("WcgName"), Date = Convert.ToDateTime(row.Field<int>("DueDate").ToString()) })
    .GroupBy(row => row["WcgName"])
    .Select(rowGroup => rowGroup.Select(row => ds.Tables["Capacity Progress to Due Date"].Rows.IndexOf(row) + 1)
    .Max()).ToList();
    for (var i = 0; i < insertAtIndexes.Count; i++){
        var emptyRow = ds.Tables["Capacity Progress to Due Date"].NewRow();
        var secondemptyRow = ds.Tables["Capacity Progress to Due Date"].NewRow();
        ds.Tables["Capacity Progress to Due Date"].Rows.InsertAt(emptyRow, insertAtIndexes[i] + i + i);
        ds.Tables["Capacity Progress to Due Date"].Rows.InsertAt(secondemptyRow, insertAtIndexes[i] + i + i);
    }
