    public class CustomConfigSection : ConfigurationSection
        {
            [ConfigurationProperty("", IsDefaultCollection = true)]
            public ConfigElementCollectionConfigElementCollection
            {
                get
                {
                    return (ConfigElementCollection)base[""];
                }
            }
    
        }
