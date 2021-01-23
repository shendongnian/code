    public static DbConnection GetOpenConnection(string dataProvider, string connectionString) 
    {
       try 
       {
          DbConnection dbConnection = GetDbProviderFactory(dataProvider).CreateConnection();
          dbConnection.ConnectionString = connectionString;
          dbConnection.Open();
          return dbConnection;
       }
       catch (Exception e) // consider changing this to a more specific type of exception, as an error with .Open() is not the only way it could fail
       {
          // provide a meaningful message to the caller about the context of this error
          var message = string.Format("An error occurred while trying to connect to the data provider {0} with the connection string {1}.", dataProvder, connectionString);
          throw new GetOpenConnectionException(message, e);
       }
    }
