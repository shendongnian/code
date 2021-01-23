    cmd.Parameters.Add("@rc", SqlDbType.Bit).Direction = ParameterDirection.Output;
        try
        {
            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            cmd.ExecuteNonQuery();
            result = Convert.ToBoolean(cmd.Parameters["@rc"].Value);    
        }
