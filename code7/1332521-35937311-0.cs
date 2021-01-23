    public class CustomListSerializer : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var values = (IEnumerable)value;
            var items = values.Cast<object>().ToList();
            var s = JsonConvert.SerializeObject(items);
            writer.WriteValue(s);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof(CustomList<object>).IsAssignableFrom(objectType);
        }
    }
    [JsonConverter(typeof(CustomListSerializer))]
    internal class CustomList<T> : List<T>
    {
         // Only used for adding JsonConverter
    }
    class Program
    {
        static void Main(string[] args)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("counting", new CustomList<int>() { 1, 2, 3, 5 });
            parameters.Add("name", "Numbers");
            parameters.Add("size", 4);
            var thing = new
            {
                Parameters = parameters,
                Name = "THING"
            };
            Console.WriteLine(JsonConvert.SerializeObject(thing));
            // {"Parameters":{"counting":"[1,2,3,5]","name":"Numbers","size":4},"Name":"THING"}
        }
    }
