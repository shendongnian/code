    public class BaseClass
    {
        public WebConnector Connector { get; set; }
        public BaseClass(){
            Connector = new WebConnector();
        }
    }
