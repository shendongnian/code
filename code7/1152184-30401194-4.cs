    // Create a DataTable
    DataTable one = new DataTable();
    one.Columns.Add("ID");
    one.Columns.Add("PCT");
    one.Rows.Add("1", "1.1"); // Same
    one.Rows.Add("2", "2.1"); // Diff 
    one.Rows.Add("3", "3.1"); // Does not exist
    // Create a second DataTable
    DataTable two = new DataTable();
    two.Columns.Add("ID");
    two.Columns.Add("PCT");
    two.Rows.Add("1", "1.1");
    two.Rows.Add("2", "2.2");
    // Get the DataTable one's diffs 
    DataTable three = two.AsEnumerable().Except(one.AsEnumerable()).CopyToDataTable();
    // Sort the results by "PCT" 
    three.DefaultView.Sort = "PCT DESC";
    // For each diff row in view
    foreach (DataRowView dr in three.DefaultView)
    {
        string id = dr["ID"].ToString();
        string pct = dr["PCT"].ToString();
    }
