    public class Details
    {
        private string _property1;
        private string _property2;
        
        [JsonProperty("property1")]
        public string prop1 {get;set;}
        
        [JsonProperty("foo")]
        public string foo {get;set;}
        
        public string getProperty1 
        {
            get {_property1=prop1??foo;return _property1;}
            set{prop1=value;foo=value;}
        }
        
        [JsonProperty("property2")]
        public string prop2 {get;set;}
        
        [JsonProperty("bar")]
        public string bar {get;set;}
        
        public string getProperty2
        {
            get {_property2=prop2??bar;return _property2;}
            set {prop2=value;bar=value;}
        }
    }
