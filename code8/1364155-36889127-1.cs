    using (SqlConnection cn = new SqlConnection(con))
    {
        cn.Open();
        string selectQuery = "Select * From Customers";
        string insertQuery = "Insert Into Customers (CompanyName , City) Values (@CompanyName, @City)";
        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.SelectCommand = new SqlCommand(selectQuery, cn);
        adapter.InsertCommand = new SqlCommand(insertQuery, cn);
        DataSet db = new DataSet();
        adapter.Fill(db, "Customers");
        var icp = adapter.InsertCommand.Parameters;
        icp.Add("@CompanyName", SqlDbType.NVarChar, 150, "CompanyName"); // optional, restrict length according to database max-length
        icp.Add("@City", SqlDbType.NVarChar, 100, "City"); 
        DataRow newRow = db.Tables["Customers"].Rows.Add();
        newRow.SetField("CompanyName", "Bon app");
        newRow.SetField("City", "london");
        int r = adapter.Update(db, "Customers");
    }
