    using (SqlConnection connect = new SqlConnection())
    {
        DataSet tmp = new DataSet();
        connect.ConnectionString = conString;
        connect.Open();
        SqlDataAdapter adapter = new SqlDataAdapter(*your query*, connect);
        adapter.Fill(tmp);
    }
    
