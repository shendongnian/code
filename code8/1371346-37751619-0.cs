    public DataSet GetComponentHistory()
    {
    	string sqlCommand = "YourSpName";
    	Database _db = DatabaseFactory.CreateDatabase();
    
    	DbCommand dbCommand = _db.GetStoredProcCommand(sqlCommand);
    	DataSet ds = _db.ExecuteDataSet(dbCommand);
    
    	return ds;
    }
