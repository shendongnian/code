    public static MongoServer GetConnection()
    {
      //var cs = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultMongoConnection"].ConnectionString;
      MongoServerSettings settings = new MongoServerSettings();
      settings.Server = new MongoServerAddress("localhost", 27017);
      MongoServer server = new MongoServer(settings);
      return server;
    }
    
    public static MongoDatabase GetDatabase(string database = "")
    {
      if (string.IsNullOrEmpty(database))
      {
        return GetConnection().GetDatabase(System.Configuration.ConfigurationManager.AppSettings.Get("MongoDbName"));
      }
      else
      {
        return GetConnection().GetDatabase(database);
      }
    }
