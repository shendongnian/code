    DataTable dt = new DataTable();
    dt.Columns.Add("A1_a"); // out
    dt.Columns.Add("A1_6"); // in
    dt.Columns.Add("A1_5"); // in
    dt.Columns.Add("A1_7"); // in
    dt.Columns.Add("A1_0"); // out
    dt.Columns.Add("A1_1"); // out
    dt.Columns.Add("A1_9"); // out
    
    // count result is: 3
  
    var count = (from col in dt.Columns.OfType<DataColumn>()
                 where Regex.IsMatch(col.ColumnName, "A1_[2-8]")
                 select col).Count();
    
