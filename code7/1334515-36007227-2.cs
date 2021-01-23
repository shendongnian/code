    public class KeyValue: ConfigurationElement
        {
            #region Constructor(s)
            public KeyValue()
            {
            }
    
            public KeyValue(string key, string value)
            {
                this.Key= key;
                this.Value= value;
            }
            #endregion
    
            #region Configuration Properties
            [ConfigurationProperty("Key", IsRequired = true)]
            public string Key
            {
                get { return this["Key"] as string; }
                set { this["Key"] = value; }
            }
    
            [ConfigurationProperty("Value", IsRequired = true)]
            public string Value
            {
                get { return this["Value"] as string; }
                set { this["Value"] = value; }
            }
            #endregion
        }
