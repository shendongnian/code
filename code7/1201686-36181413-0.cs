    public static SqlConnection GetConnection(string connectionName)
    {
    	SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[connectionName].ConnectionString);
    	conn.Open();
    	return conn;
    }
    
    public string dbLoginWorker(int workerNumber)
    {
    	using (conn = GetConnection("dbConnect"))
    	{
    		if (CanFindWorkerNumber(conn, workerNumber))
    			ExecuteProcedure1(conn);
    		else
    			ExecuteProcedure2(conn);
    	}
    }
    
    public bool CanFindWorkerNumber (SqlConnection conn, int workerNumber)
    {
    	bool success = false;
    	using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 column FROM table WHERE id= @workernumber", conn))
    	{
    		cmd.Parameters.Add("@workernumber", SqlDbType.Decimal);
    		cmd.Prepare();
    		cmd.Parameters[0].Value = workerNumber;
    		success = cmd.ExecuteScalar() != null;		
    	}
    	return success;
    }
    
    public void ExecuteProcedure1(SqlConnection conn)
    {
    	using (SqlCommand cmd = new SqlCommand("STORED_PROCEDURE1", conn))
    	{
    		cmd.CommandType = CommandType.StoredProcedure;
    		cmd.Parameters.Add("@ID", SqlDbType.Decimal);
    		cmd.Parameters.Add("@VARCHAR", SqlDbType.VarChar);
    		cmd.Prepare();
    		cmd.Parameters[0].Value = workerNumber;
    		cmd.Parameters[1].Value = "text";
    		cmd.ExecuteNonQuery();
    	}
    }
     
    public void ExecuteProcedure1(SqlConnection conn)
    {
    	using (SqlCommand cmd = new SqlCommand("STORED_PROCEDURE1", conn))
    	{
    		cmd.CommandType = CommandType.StoredProcedure;
    		cmd.Parameters.Add("@ID", SqlDbType.Decimal);
    		cmd.Parameters.Add("@INT", SqlDbType.SmallInt).Value);
    		cmd.Parameters.Add("@VARCHAR", SqlDbType.VarChar);
    		cmd.Prepare();
    		cmd.Parameters[0] = workerNumber;
    		cmd.Parameters[1] = 1;
    		cmd.Parameters[2] = "text";
    		cmd.ExecuteNonQuery();
    	}
    }
