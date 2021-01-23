    public class MyContract 
    {
        [JsonProperty("head")]
        public MetaObject Head 
        {
            get; set;
        }
        
        // Not sure if this will work, but it probably will
        [JsonProperty("object")]
        public JObject ExtendedInformation
        {
            get;
            set;
        }
        
        [JsonProperty("rule")]
        public Rule[] Rules 
        {
            get;
            set;
        }
    }
    
    // "MetaObject" definition omitted but you can understand my point with the below
    
    public class Rule
    {
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }
        
        [JsonProperty("value")]
        public string Value
        {
            get;
            set;
        }
    }
