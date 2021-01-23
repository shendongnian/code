    using (SqlConnection con = new System.Data.SqlClient.SqlConnection(connString))
    {
       using (SqlCommand cmd = new SqlCommand())
       {
        cmd.CommandText = "query";
           cmd.Connection = con;
        con.Open();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adapter.Fill(ds);
        con.Close();
       }
    }
