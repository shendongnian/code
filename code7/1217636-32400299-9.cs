    public IDataReader ExecuteDataReaderAsync(string connectionString, CommandType cmdType, string spName, params SqlParameter[] cmdParameters)
    {
        // These two are intentionally are not in a using statement, but it is ok, closing 
        // the reader cleans up the resources.
        var conn = new SqlConnection(connectionString))
        var cmd = new SqlCommand(spName, conn))
    
        cmd.CommandType = cmdType;
        cmd.Parameters.AddRange(cmdParameters);
        conn.Open();
        var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        return new CleaningDataReader(reader, cmd, conn);
    }
