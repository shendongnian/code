	public static DatabaseFactory
	{
	    public static DatabaseProvider Create(string key)
		{
			var providerType = GetProviderTypeFromConfig(key);
			var connectionString = GetConnectionFromConfig(key);
	
	        if (providerType == ProviderType.Sql) 
	            return new SqlDatabaseProvider(connectionString);
		    if (providerType == ProviderType.Oracle) 
	            return new OracleDatabaseProvider(connectionString);
	        throw new NotImplementedException("Provider not found"); 
	    }
	}
