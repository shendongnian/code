    public class User
    {
        private static readonly User _instance;
        private static object syncRoot = new Object();
    	
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string SomeOtherProperty { get; set; }
    	
        private User()
        { 
    	    // Initialize defaults
        }
        public void Reset()
	    {
            // Clear existing values
	    }
    	public static User Instance
        {
    		get 
    		{ 
    			if (instance == null) 
    			{
    				lock (syncRoot) 
    				{
    					if (_instance == null) 
    						_instance = new User();
    					return _instance; 
    				}
    			}
    		}
    	}	
    }
