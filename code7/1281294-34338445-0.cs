    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlDataAdapter dap = new SqlDataAdapter(sqlCommand,connection);
        DataTable datatable = new DataTable();
        dap.Fill(datatable);
        return datatable;
    }
