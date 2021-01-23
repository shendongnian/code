    public class AppSettings
    {
        public AppSettings()
        {
            Dms = new Dms(); // need to instantiate (Configuration only sets properties not create the object)
            Sms = new Sms(); // same
        }
    
        public string SiteTitle { get; set; }
        public Dms Dms { get; set; }
        public Sms Sms { get; set; }
    }
    
    public class Dms
    {
        public string Url { get; set; }
        public int MaxRetries { get; set; }
    }
    
    public class Sms
    {
        public string FromNumber { get; set; }
        public string ApiKey { get; set; }
    }
