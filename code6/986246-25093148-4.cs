    List<string> colSaved = new List<string>();
    for (int n = dt.Columns.Count - 1; n >= 0; n--)
    {
        if (total[n].ToString() == "0")
            dt.Columns.RemoveAt(n);
        else
            colSaved.Add(dt.Columns[n].ColumnName);
    }
    .....
    .....
    string[] columns = colSaved.ToArray();
