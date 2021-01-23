    public class MyConfigElement: ConfigurationElement
        {
            [ConfigurationProperty("key", IsRequired = true, IsKey = true)]
            public string key
            {
                get
                {
                    return (string)base["key"];
                }
            }   
    }
