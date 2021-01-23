    public class TestClass
    {
        [JsonConverter(typeof(JsonScientificConverter))]
        public int Value { get; set; }
    }
    
    static void Main(string[] args)
    {
        var json = "{Value:9.658055e+06}";
    
        var xx = JsonConvert.DeserializeObject<TestClass>(json);
    }
    
    public class JsonScientificConverter : JsonConverter
    {
        public override bool CanRead { get { return true; } }
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
        
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
        
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return (int)(serializer.Deserialize<System.Int64>(reader));
        }
    }
