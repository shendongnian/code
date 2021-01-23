    OracleConnection cn = null;
	try
	{
	    cn = new OracleConnection(connectionString);
		OracleCommand cmd = null;
		try
		{
			cmd = new OracleCommand(sql, cn);
		}
		finally
		{
		    if(cmd != null)
			    cmd.Dispose();
		}
	}
	finally
	{
		if(cn != null)
			cn.Dispose();
	}
	
