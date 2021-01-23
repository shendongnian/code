    public class Finder : BaseClass
    {
        public Finder() 
        {
            Connector = new WebConnector();
        }
        public String GetBuild()
        {
            var path = Connector.GetUrl(Id, baseUrl);
        }
    }
