    protected void Button1_Click(object sender, EventArgs e)
    {
        DataTable dataTable = new DataTable();
        using (var conn = new SqlConnection(connString))
        using (var cmd = new SqlCommand("select * from tbl_news", conn))
        using (var da = new SqlDataAdapter(cmd))
        {
            // no need to open the connection with DataAdapter.Fill
            da.Fill(dataTable);
        } // no need to close the connection with using-statement anyway
        // do something with the table here, f.e. assign it as datasource 
        // for a webdatabound control like GridView
        // ...
    }
