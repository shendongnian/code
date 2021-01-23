    public static DbConnection GetConnection()
    {
    	//Get the connection string info from our application config
    	ConnectionStringSettings cs = ConfigurationManager.ConnectionStrings["Program.Properties.Settings.InventoryDBConnectionString"];
    
    	if (cs == null)
    		throw new Exception("Could not find connection string settings");
    
    	//Get the factory for the given provider (e.g. "System.Data.OleDbClient")
    	DbProviderFactory factory = DbProviderFactories.GetFactory(cs.ProviderName);
    
    	if (factory == null)
    		throw new Exception("Could not obtain factory for provider \"" + cs.ProviderName + "\"");
    
    	//Have the factory give us the right connection object
    	DbConnection conn = factory.CreateConnection();
    
    	if (conn == null)
    		throw new Exception("Could not obtain connection from factory");
    
    	//Knowing the connection string, open the connection
    	conn.ConnectionString = cs.ConnectionString;
    	conn.Open();
    
    	return conn;
    }
