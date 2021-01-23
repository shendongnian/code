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
            return objectType.IsAssignableFrom(typeof(IEnumerable));
        }
    }
    [JsonConverter(typeof(CustomListSerializer))]
    internal class CustomList<T> : List<T>
    {
    }
    class Program
    {
        static void Main(string[] args)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("counting", new CustomList<int>() { 1, 2, 3, 5 });
            parameters.Add("users", new CustomList<User>() { new User { Name = "TryingToImprove" }, new User { Name = "rubenvb" } });
            parameters.Add("name", "Numbers");
            parameters.Add("size", 4);
            var thing = new
            {
                Parameters = parameters,
                Name = "THING",
                Test = new List<int>() {  1, 2, 3}
            };
            Console.WriteLine(JsonConvert.SerializeObject(thing));
        }
    }
    internal class User
    {
        public string Name { get; set; }
    }
