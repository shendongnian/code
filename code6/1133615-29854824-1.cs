	OracleCommand cmd = null;
	try
	{
		cmd = new OracleCommand(sql, new OracleConnection(connectionString));
	}
	finally
	{
		if(cmd != null)
			cmd.Dispose();
	}
    
