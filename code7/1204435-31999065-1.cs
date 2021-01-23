    using(SqlConnection con = new SqlConnection(....))
    {
        SqlCommand cmd = new SqlCommand("select * from Users;");
        cmd.Connection = con;
        con.Open();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
    }
