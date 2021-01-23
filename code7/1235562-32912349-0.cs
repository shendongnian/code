    public class BaseClass
    {
        public BaseClass() 
        {
           Connector = new WebConnector();
        }
    
        public WebConnector Connector { get; set; }
    
    }
