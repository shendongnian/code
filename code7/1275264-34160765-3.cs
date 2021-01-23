    public class Json_34159840
    {
        public static string JsonStr = @"{""enum"":""1Value"",""name"":""James"",""enum2"":""1""}";
        public static void ParseJson()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { new EnumConverter() }
            };
            // Later on...
            var result = JsonConvert.DeserializeObject<JsonClass>(JsonStr);
            Console.WriteLine(result.Enum);
            Console.WriteLine(result.Enum2);
            Console.WriteLine(result.Name);
        }
    }
    public class EnumConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = reader.Value.ToString();
            if (Regex.IsMatch(value, @"^\d+$"))
            {
                return Enum.Parse(objectType, value);
            }
            if (Regex.IsMatch(value, @"^\d+"))
            {
                value = "_" + value;
            }
            return Enum.Parse(objectType, value);
        }
        public override bool CanConvert(Type objectType)
        {
            //You might want to do a more specific check like
            //return objectType == typeof(JsonEnum);
            return objectType.IsEnum;
        }
    }
    public enum JsonEnum
    {
        _0Default,
        _1Value
    }
    public class JsonClass
    {
        public string Name { get; set; }
        public JsonEnum Enum { get; set; }
        public JsonEnum Enum2 { get; set; }
    }
