    public OdbcDataReader QueryReader(OdbcCommand command)
    {
        var connection = GetConnection();
        connection.Open;
        try
        {
            command.Connection = connection;
            command.Prepare();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
        finally
        {
            //connection.Close();
        }
    }
