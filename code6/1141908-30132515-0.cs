    using (SqlConnection connectionx = new SqlConnection(CONNECTIONSTRING))
    {
        if(connectionx.State != ConnectionState.Open
            connectionx.Open();
        cmd.CommandText = queuery;
        cmd.CommandType = CommandType.Text;
        cmd.Connection = connectionx;
        reader = cmd.ExecuteReader();
        
        connectionx.Close();
    }
