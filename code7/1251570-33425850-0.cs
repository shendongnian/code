    using (var dbConnection  = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateConnection())
    {
    	dbConnection.ConnectionString = connectionString;
        dbConnection.Open();
    	using (var dbTransaction = dbConnection.BeginTransaction())
    	{
    		//Do work here
    
    		dbTransaction.Commit();
    	}
    }
