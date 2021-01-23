    public void Execute(string sql) // execute Insert, Delete etc..
    {
        OleDbCommand ocmd = new OleDbCommand();
        ocmd.CommandText = sql;
        ocmd.Connection = con;
        Execute(ocmd);  
    }
    public void Execute(OleDbCommand cmd)
    {
	try
	{
        	int result=cmd.ExecuteNonQuery();
        	cmd.Dispose();
	}catch (Exception ex){
		Console.Write(ex.Message);
	}
    }
