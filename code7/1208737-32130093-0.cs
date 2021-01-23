    private void DebugSqlUserDefinedFunctions(SqlCommand cmd)
    {
    	Server svr = new Server(new ServerConnection(cmd.Connection));
    	foreach (var udf in svr.Databases[cmd.Connection.Database].UserDefinedFunctions.Cast<Microsoft.SqlServer.Management.Smo.UserDefinedFunction>().Where(udf => !udf.IsSystemObject))
    	{
    		System.Diagnostics.Debug.WriteLine(udf.Name);
    	}
    }
