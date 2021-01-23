    DataTable dt = new DataTable("SO Example");
    
    dt.Columns.Add("A", typeof(int));
    dt.Columns.Add("B", typeof(string));
    dt.Columns.Add("C", typeof(string));
    dt.Columns.Add("D", typeof(string));
    dt.Columns.Add("Concatenation", typeof(string));
    
    dt.Rows.Add(1, "bbbbbb", "tra la la", "d");
    dt.Rows.Add(2, "b b b", "tttt", "dddddd");
    dt.Rows.Add(3, "b-b-b-b-b-b", "C", "d.d.d.d.d.d");
    dt.Rows.Add(4, "bBbBbBb", "CCC", "dd");
    dt.Rows.Add(5, "B", "C", "D");
    
    foreach (DataRow row in dt.Rows)
    {
        row["Concatenation"] = string.Join(", ", row.ItemArray.Take(row.ItemArray.Length - 1));
    }
