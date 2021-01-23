    namespace Custom
    {
     public class CountrySettingSection : ConfigurationSection
        {
            // Create a "customKey" attribute.
            [ConfigurationProperty("customKey", DefaultValue = "0", IsRequired = false)]
            public int CustomKey
            {
                get
                { 
                    return (int)this["customKey"]; 
                }
                set
                { 
                    this["customKey"] = value; 
                }
            }
    }
