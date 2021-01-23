    void Main()
    {
        var json=  @"{
        SomeKey : ""SomeValue"",
        SecondaryProperties: {
            Property1: { ""Id"" : ""ABC"", ""Label"" : ""Property One"", ""Value"" : 1 },
            Property2: { ""Id"" : ""DEF"", ""Label"" : ""Property Two"", ""Value"" : 10 },
            Property3: { ""Id"" : ""GHI"", ""Label"" : ""Property Three"", ""Value"" : 5 },
            Banana: { ""Id"" : ""YUM"", ""Label"" : ""Property Four"", ""Value"" : 5 },
            WeJustAddedThis: { ""Id"" : ""XYZ"", ""Label"" : ""Property Five"", ""Value"" : 1 }
        }
    }"; 
    
        var result = JsonConvert.DeserializeObject<Root>(json);
    }
    
    public class Property
    {
    
        [JsonProperty("Id")]
        public string Id { get; set; }
    
        [JsonProperty("Label")]
        public string Label { get; set; }
    
        [JsonProperty("Value")]
        public int Value { get; set; }
    }
    
    
    
    public class Root
    {
    
        [JsonProperty("SomeKey")]
        public string SomeKey { get; set; }
    
        [JsonProperty("SecondaryProperties")]
        public Dictionary<string, Property> SecondaryProperties { get; set; }
    }
