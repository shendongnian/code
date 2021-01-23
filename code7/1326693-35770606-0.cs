    public class Controller
    {
    	public Controller()
    	{
    		Config = new Configuration();
    	}
    	public class Configuration
    	{
    
    		// Properties of the Database
    		public string Name { get; set; }
    		public string BusinessID { get; set; }
    		public string Address { get; set; }
    
    	}
    
    	public Configuration Config { get; set; }
    
    }
    // istantiate a controller.configuration instance
    Controller cont = new Controller();
    // and use his properties
    cont.Config.Name = "test";
