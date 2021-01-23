    public class Deployment
    {
        [XmlElement(IsNullable = true)]
        public AppPoolSettings AppPool { get; set; }
        [XmlElement(IsNullable = true)]
        public WebSiteSettings Site { get; set; }
        public Deployment()
        {
            //the object constructors below init their internal properties as well...
            this.AppPool = new AppPoolSettings();
            this.Site = new WebSiteSettings();
        }
    }
