    public class Controller
    {
   
        public class Configuration
        {
    
            // Properties of the Database
            public string Name { get; set; }
            public string BusinessID { get; set; }
            public string Address { get; set; }
    
        }
    
        // If you don't want external code set the internal instance remove the set method 
        public Configuration ctrlConfig {get;set;}
        public Controller()
        {
             // Remember to initialize the inner instance of the configuration
             ctrlConfig = new Configuration()
        }
    }
