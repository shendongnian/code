        public class ClassB
        {
            public int Id { get; set; }
    
            [JsonProperty(Required = Required.Always)]
            public string SomeString { get; set; }
    
        }
