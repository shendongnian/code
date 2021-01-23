    public class Deployment
    {
        public AppPoolSettings AppPool { get; set; }
        public WebSiteSettings Site { get; set; }
        // used by deserializer
        public Deployment() { }
        // use this to construct object
        public static Deployment Create()
        {
            return new Deployment()
            {
                AppPool = new AppPoolSettings(),
                Site = new WebSiteSettings()
            };
        }
    }
