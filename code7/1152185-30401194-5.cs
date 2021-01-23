    // Create a DataTable
    DataTable one = new DataTable();
    one.Columns.Add("ID");
    one.Columns.Add("PCT");
    one.Rows.Add("1", "1.1"); 
    one.Rows.Add("3", "3.1"); // Not in two 
    // Create a second DataTable
    DataTable two = new DataTable();
    two.Columns.Add("ID");
    two.Columns.Add("PCT");
    two.Rows.Add("1", "1.1"); // Occur in one
    two.Rows.Add("2", "2.2"); // Does not occur in one
    // Perform the Except 
    // one: whose elements that are not also in second will be returned.
    // two: whose elements that also occur in the first sequence 
    //        will cause those elements to be removed from the returned sequence.
    DataTable three = one.AsEnumerable().Except(two.AsEnumerable()).CopyToDataTable();
    //// Sort the results by "PCT" 
    three.DefaultView.Sort = "PCT DESC";
    // For each diff row in view
    foreach (DataRowView dr in three.DefaultView)
    {
        string id = dr["ID"].ToString();
        string pct = dr["PCT"].ToString();
    }
    // Returns two rows:
    // "3", "3.1"
    // "1", "1.1"
