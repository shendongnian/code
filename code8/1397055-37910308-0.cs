    public class MyFirstClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MySecondClass> Roles { get; set; }
    }
    public class MySecondClass
    {
        public List<MyThirdClass> Roles { get; set; }
    }
    public class MyThirdClass
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
    public sealed class MyThirdClassStringConverter : JsonConverter
    {
        readonly JsonSerializerSettings settings;
        public MyThirdClassStringConverter() : this(null) { }
        public MyThirdClassStringConverter(JsonSerializerSettings settings)
        {
            this.settings = settings;
        }
        JsonSerializer GetInnerSerializer()
        {
            var innerSerializer = JsonSerializer.CreateDefault(settings);
            for (int i = innerSerializer.Converters.Count - 1; i >= 0; i--)
                if (innerSerializer.Converters[i] is MyThirdClassStringConverter)
                    innerSerializer.Converters.RemoveAt(i);
            return innerSerializer;
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof(MyThirdClass).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var innerSerializer = GetInnerSerializer();
            if (reader.TokenType == JsonToken.String)
            {
                var s = reader.Value.ToString();
                using (var innerReader = new StringReader(s))
                    return innerSerializer.Deserialize(innerReader, objectType);
            }
            else
            {
                return innerSerializer.Deserialize(reader, objectType);
            }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var innerSerializer = GetInnerSerializer();
            var sb = new StringBuilder();
            using (var innerWriter = new StringWriter(sb))
                innerSerializer.Serialize(innerWriter, value);
            writer.WriteValue(sb.ToString());
        }
    }
