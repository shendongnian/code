    void Main()
    {
        var jsonStrings = new[]
        {
            "{ \"prop\": \"identifier\" }",
            "{ \"prop\": { \"complex\": \"object\" } }"
        };
    
        jsonStrings.Select(json => JsonConvert.DeserializeObject<Test>(json)).Dump();
    }
    
    public class Test
    {
        public Test()
        {
            _Complex = new Lazy<Complex>(GetComplex);
        }
    
        [JsonProperty("prop")]
        public dynamic prop { get; set; }
    
        [JsonIgnore]
        public string Identifier => prop as string;
    
        private readonly Lazy<Complex> _Complex;
    
        [JsonIgnore]
        public Complex Complex => _Complex.Value;
    
        private Complex GetComplex()
        {
            if (!(prop is JObject))
                return null;
    
            return ((JObject)prop).ToObject<Complex>();
        }
    }
    
    public class Complex
    {
        public string complex { get; set; }
    }
