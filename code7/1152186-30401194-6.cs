    // Create a DataTable
    DataTable one = new DataTable();
    one.Columns.Add("ID", typeof(int));
    one.Columns.Add("PCT", typeof(double));
    one.PrimaryKey = new DataColumn[] { one.Columns["ID"] };
    one.Rows.Add(1, 1.0); // Occur in two, same
    one.Rows.Add(2, 2.0); // Occurs in two, but different
    one.Rows.Add(3, 3.0); // Not in two 
    one.Rows.Add(5, 5.0); // Occur in two, same
    // Create a second DataTable
    DataTable two = new DataTable();
    two.Columns.Add("ID", typeof(int));
    two.Columns.Add("PCT", typeof(double));
    two.PrimaryKey = new DataColumn[] { two.Columns["ID"] };
    two.Rows.Add(1, 1.0); // Occur in one, same
    two.Rows.Add(2, 2.1); // Occurs in one, but different
    two.Rows.Add(4, 4.0); // Not in one
    two.Rows.Add(5, 5.0); // Occur in one, same
    // Perform the Except 
    // one: whose elements that are not in second will be returned.
    // two: whose elements that also occur in the first sequence will cause those elements to be removed from the returned sequence.
    DataTable oneTwo = one.AsEnumerable().Except(two.AsEnumerable()).CopyToDataTable();
    DataTable twoOne = two.AsEnumerable().Except(one.AsEnumerable()).CopyToDataTable();
    // Sort the results by "PCT" 
    oneTwo.DefaultView.Sort = "PCT DESC";
    twoOne.DefaultView.Sort = "PCT DESC";
    // For each row (one except two)
    foreach (DataRowView dr in oneTwo.DefaultView)
    {
        string id = dr["ID"].ToString();
        string pct = dr["PCT"].ToString();
    }
    // Returns four rows
    // 5, 5
    // 3, 3
    // 2, 2
    // 1, 1  
    // For each row (two except one)
    foreach (DataRowView dr in twoOne.DefaultView)
    {
        string id = dr["ID"].ToString();
        string pct = dr["PCT"].ToString();
    }
    // Returns four rows
    // 5, 5
    // 4, 4
    // 2, 2.1
    // 1, 1  
    // Another Solution
    // Or you can just do a WHERE
    DataTable three = two.AsEnumerable().Where(r2 => !one.AsEnumerable().Any(r1 => r1.Field<int>("ID") == r2.Field<int>("ID") &&
                                                                                    r1.Field<double>("PCT") == r2.Field<double>("PCT")))
                                        .CopyToDataTable();
    three.DefaultView.Sort = "PCT DESC";
                
    // For each row (based on where)
    foreach (DataRowView dr in three.DefaultView)
    {
        string id = dr["ID"].ToString();
        string pct = dr["PCT"].ToString();
    }
    // Returns two rows
    // 4, 4  
    // 2, 2.1
