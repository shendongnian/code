    interface IDatabaseManager
    {
      IDbConnection OpenConnection(string databaseName);
      IDbCommand CreateCommand(string command, IDbConnection connection);
    }
    class MyClass
    {
    	private IDatabaseManager  _databaseManager;
    	public MyClass(IDatabaseManager databaseManager)
    	{
    		_databaseManager = databaseManager;
    	}
    	
    	public void ExecutScalarMethod()
    	{
    		using (var objCon = _databaseManager.OpenConnection(DBNAME))
    		{
    		  objCon.Open();
    		  using (SQLiteCommand objCmd = _databaseManager.CreateCommand(strSQL, objCon))
    		  {
    				objRetValue = objCmd.ExecuteScalar();
    				objCmd.Dispose();
    		  }
    		  objCon.Close();
    		  objCon.Dispose();
    		}
    	}
    }
