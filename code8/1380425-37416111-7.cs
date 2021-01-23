    public class CustomSiteSettingsSection : ConfigurationSection
    {
        [ConfigurationProperty("Sites")]
        [ConfigurationCollection(typeof(SiteCollection), AddItemName="Site")]
        public SiteCollection Sites
        {
            get
            {
                return (SiteCollection)base["Sites"];
            }
        }           // end of public SiteCollection Site
    }               // end of public class CustomSiteSettings : ConfigurationSection { 
