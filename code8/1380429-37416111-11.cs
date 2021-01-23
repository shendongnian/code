    public class SiteSettingElement : ConfigurationElement
    {
        public SiteSettingElement() { }
        [ConfigurationProperty("name", IsRequired=true, IsKey=true)]
        public String name
        {
            get { return (String)this["name"]; }
            set { this["name"] = value; }
        }           // end of public String name
        [ConfigurationProperty("value", IsRequired = true)]
        public String value
        {
            get { return (String)this["value"]; }
            set { this["value"] = value; }
        }           // end of public String value
    }               // end of public class SiteSettingElement : ConfigurationElement
