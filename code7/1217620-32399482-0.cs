    DataTable newTable = new DataTable();
    newTable.Columns.Add(new DataColumn("Account#", typeof(string)));
    newTable.Columns.Add(new DataColumn("Occurrences", typeof(int)));
    foreach(var result in results)
    {
        var row = newTable.Rows.NewRow();
        row[0] = result.Account;
        row[1] = result.Occurrences;
        newTable.Rows.Add(row);
    }
