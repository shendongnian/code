    var strSQL = "SELECT * FROM TABLE(SCHEMA.PKG.SPNAME('PARAMS'));";
    using (OracleConnection connStr = new OracleConnection(connectionString))
    {         
    	using (OracleCommand cmd = new OracleCommand(strSQL, connStr))
    	{
    		cmd.CommandType = CommandType.Text;
    		cmd.Connection.Open();
    		cmd.ExecuteScalar(); //change the ExecuteScalar to fit the proper call
    	}
    }
