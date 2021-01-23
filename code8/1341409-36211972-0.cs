    public static class Globals
    {
        // define properties
    	public static string Server { get; set; }
    	public static string Username { get; set; }
        // encapsulate the Settings.Environment in a property
        public public static string Environment 
        {
           get { return MyApp.Properties.Settings.Default.Environment; }
        }
    
        // when the application starts, this static scope will execute!
    	static Globals()
    	{
    		switch (environment)
    		{
    			case "development":
    				Server = "SQL1";
    				Username = "dev.user";
    				break;
    			case "test":
    				Server = "SQL2";
    				Username = "test.user";
    				break;
    			case "production":
    				Server = "SQL3";
    				Username = "prod.user";
    				break;
                default:
    				Server = "SQL1";
    				Username = "dev.user";
    		}
    	}
    }
