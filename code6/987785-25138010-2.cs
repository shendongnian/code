    public DataSet Ds_getLoginDetails(string LoginID, string LoginPassword)
    {
        var ds = new DataSet();
    
        using (var conn = new SqlConnection("Your connection string comes here"))
        using (var cmd = conn.CreateCommand())
        {
            conn.Open();
            cmd.CommandText = "select * from Users where LoginID=@LoginID and Password=@Password";
            cmd.Parameters.AddWithValue("@LoginID", LoginID);
            cmd.Parameters.AddWithValue("@Password", LoginPassword);
    
            var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
        }
        return ds;
    }
