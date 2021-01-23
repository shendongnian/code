    using (OracleConnection con = new OracleConnection("user id=You;password=Pass;data source=DB"))
    {
        con.Open();
        using (OracleCommand cmd = new OracleCommand("create table YourTableName(ID number)", con))
        {
            cmd.ExecuteNonQuery();
        }
    }
