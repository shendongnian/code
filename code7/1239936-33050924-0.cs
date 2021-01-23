    using (var conn = new SqlConnection(connectionString))
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM YourTableName", conn);
        SqlDataAdapter da = new SqlDataAdapter() { SelectCommand = cmd };
    
        // Load records to a DataSet
        DataSet ds = new DataSet();
        da.Fill(ds, "YourTableName");
        var table = ds.Tables["YourTableName"];
    
        // Add a new row with default value
        table.Rows.Add();
    
        SqlCommandBuilder cb = new SqlCommandBuilder(da);
        da.Update(ds, "YourTableName");
    }
