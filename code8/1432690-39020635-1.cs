	public static class VersionContextConnection
	{
		public static DbConnection GetDatabaseConnection()
		{
			var providerName = "Npgsql"; //Get this
			var databaseName = decryptedDatabaseName;
			var userName = decryptedUserName;
			var password = decryptedPassword;
			var host = decryptedHostName
			var port = 5432;
			//Insert it here
			var conn = DbProviderFactories.GetFactory(providerName).CreateConnection(); 
			conn.ConnectionString = $"Server={host}; " + $"Port={port}; " + 
				$"User Id={userName};" + $"Password={password};" + $"Database={databaseName};";
			return conn;
		}
	}
