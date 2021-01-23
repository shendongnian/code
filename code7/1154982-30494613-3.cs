    var table = new DataTable();
    var column = new DataColumn {ColumnName = "column1"};
    table.Columns.Add(column);
    column = new DataColumn {ColumnName = "column2"};
    table.Columns.Add(column);
    var row = table.NewRow();
    row["column1"] = "1";
    row["column2"] = "ABC";
    table.Rows.Add(row);
    string output = "";
    foreach (DataRow r in table.Rows)
    {
        output = table.Columns.Cast<DataColumn>()
                      .Aggregate(output, (current, c) => current + 
                          string.Format("{0}='{1}' ", c.ColumnName, (string) r[c]));
        output = output + Environment.NewLine;
    }
    // output should now contain "column1='1' column2='ABC'"
