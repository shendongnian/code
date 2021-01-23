    public class ProcessConfigElement : ConfigurationElement
    {
        [ConfigurationProperty("sources", IsDefaultCollection = false)]
        public HttpConfigElementCollection Sources
        {
            get { return (HttpConfigElementCollection)base["sources"]; }
    
        }
    
        [ConfigurationProperty("destinations", IsDefaultCollection = false)]
        public DestinationConfigElement Destinations
        {
            get { return (DestinationConfigElement)base["destinations"]; }
    
        }
    }
