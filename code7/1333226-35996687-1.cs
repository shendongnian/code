    public class DestinationConfigElement : ConfigurationElement
    {
        [ConfigurationProperty("isactive", IsRequired = false, IsKey = false, DefaultValue = "")]
        public string IsActive
        {
            get { return (string)this["isactive"]; }
            set { this["isactive"] = value; }
        }
    
        [ConfigurationProperty("endpoints", IsDefaultCollection = false)]
        public HttpConfigElementCollection Endpoints
        {
            get { return (HttpConfigElementCollection)base["endpoints"]; }
    
        }
    }
