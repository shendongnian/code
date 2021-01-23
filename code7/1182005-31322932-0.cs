    String sql = "select Balance from PlayerAccount where Player_User=@user";
    using(OleDbConnection con = new OleDbConnection(ConnectionString))
    {
        con.Open();
        using(OleDbCommand comm = new OleDbCommand(sql, con))
        {
            ... Add parameters, execute query, return results
        }
    }
