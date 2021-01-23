    DataSet ds = new DataSet();
    
    ds.Tables.Add("Invoices");
    ds.Tables["Invoices"].Columns.Add("OwnerID");
    ds.Tables["Invoices"].Columns.Add("First Name");
    ds.Tables["Invoices"].Columns.Add("Last Name");
    ds.Tables["Invoices"].Columns.Add("Street");
    ds.Tables["Invoices"].Columns.Add("Zip");
    while (reader.Read())
    {
        //Get your data by line.
        string1 = reader.GetInt32(0);
        string2 = reader.GetInt32(1);
        string3 = reader.GetInt32(2);
        string4 = reader.GetInt32(3);
        string5 = reader.GetInt32(4);
        ds.Tables["Invoices"].Rows.Add(string1, string2, string3, string4, string5 );
    }
    
    GridViewStatements.DataSource = ds;
    GridViewStatements.DataBind();
