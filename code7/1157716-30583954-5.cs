    public class MyConfigElement: ConfigurationElement
    {
        [ConfigurationProperty("key", IsRequired = true, IsKey = true)]
        public string Key
        {
            get
            {
                return (string)base["key"];
            }
        }   
    }
