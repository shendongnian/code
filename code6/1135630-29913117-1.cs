            [ConfigurationProperty("name")]
            public string Name
            {
                get { return ((string)this["name"]); }
            }
    
            [ConfigurationProperty("title")]
            public string Title
            {
                get { return ((string)this["title"]); }
            }
    
            [ConfigurationProperty("description")]
            public string Description
            {
                get { return ((string)this["description"]); }
            }
