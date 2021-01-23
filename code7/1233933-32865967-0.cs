        void Main()
        {
            var factory = new DBFactory();
        	var context = factory.GetContext("NewEntities123");
        	var context2 = factory.GetContext("SomeOtherDatabase");
        }
        
        public class DBFactory
        {
        	public DBContext GetContext(string dbName)
        	{
        		return new NewEntities((ConfigurationManager.ConnectionStrings[dbName]).ToString());
        	}
        }
    
    void Main()
    {
    	//instead of passing in the database name here you could 
    	//just use a single config value for a database and that
    	//database would be different for your different apps
    	//then it would just be  var context = factory.GetContext();
    	var context = factory.GetContext("NewEntities123");
    }
    
    public class DBFactory
    {
    	public DBContext GetContext(string dbName)
    	{
    		switch(dbName)
    		{
    			case "NewEntities123":
    				return new NewEntities((ConfigurationManager.ConnectionStrings[dbName]).ToString());
    			case "SomeOtherDatabase":
    				return new SomeOtherEntities((ConfigurationManager.ConnectionStrings[dbName]).ToString());
    		}
    	}
    }
