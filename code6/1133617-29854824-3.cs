	OracleCommand cmd = new OracleCommand(sql, new OracleConnection(connectionString));
	try
	{
        // Use cmd here.
	}
	finally
	{
		if(cmd != null)
			((IDisposable)cmd).Dispose();
	}
    
