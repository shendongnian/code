    OracleConnection cn = new OracleConnection(connectionString);
	try
	{
		OracleCommand cmd = new OracleCommand(sql, cn);
		try
		{
            // Use cmd and cn here.
		}
		finally
		{
		    if(cmd != null)
			    ((IDisposable)cmd).Dispose();
		}
	}
	finally
	{
		if(cn != null)
			((IDisposable)cn).Dispose();
	}
	
