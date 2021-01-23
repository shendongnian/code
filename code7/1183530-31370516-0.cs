    class Program
    {
        static void Main(string[] args)
        {
            string json = File.ReadAllText("Sample.json");
            Desc result = JsonConvert.DeserializeObject<Desc>(json);
            result.rgDescriptions.ForEach(s => Console.WriteLine(s.market_hash_name));
            Console.ReadLine();
        }
    }
    public class Desc
    {
        [JsonConverter(typeof(DescConverter))]
        public List<Something> rgDescriptions { get; set; }
    }
    public class Something
    {
        public string appid { get; set; }
        public string classid { get; set; }
        public string market_hash_name { get; set; }
    }
    class DescConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Something[]);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var descriptions = serializer.Deserialize<JObject>(reader);
            var result = new List<Something>();
            foreach (JProperty property in descriptions.Properties())
            {
                var something = property.Value.ToObject<Something>();
                result.Add(something);
            }
            return result;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
