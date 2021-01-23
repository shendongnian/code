    public class SiteElement : ConfigurationElement
    {
        // Constructor
        public SiteElement() { }
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public String name
        {
            get { return (String)this["name"]; }
            set { this["name"] = value; }
        }           // end of public String name
        [ConfigurationProperty("siteRoot", IsRequired = true)]
        public String siteRoot
        {
            get { return (String)this["siteRoot"]; }
            set { this["siteRoot"] = value; }
        }           // end of public String siteRoot
        [ConfigurationProperty("siteSettings", IsRequired=false)]
        [ConfigurationCollection(typeof(SiteSettingsElementCollection), AddItemName = "setting")]
        public SiteSettingsElementCollection siteSettings
        {
            get
            {
                return (SiteSettingsElementCollection)base["siteSettings"];
            }
        }           // end of public SiteCollection Site
    }               // end of public class SiteElement : ConfigurationElement
