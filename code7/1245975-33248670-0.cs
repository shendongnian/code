    public class MyClassConverter : JsonConverter
    {
        const string Prefix = "My Value Is: ";
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var myClass = (MyClass)value;
            writer.WriteStartObject();
            if (myClass.StringValue != null 
                || (serializer.NullValueHandling != NullValueHandling.Ignore 
                    && (serializer.DefaultValueHandling & DefaultValueHandling.Ignore) != DefaultValueHandling.Ignore))
            {
                writer.WritePropertyName("StringValue");
                if (myClass.StringValue == null)
                    writer.WriteNull();
                else
                    serializer.Serialize(writer, Prefix + myClass.StringValue);
            }
            writer.WriteEndObject();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var s = (string)JValue.Load(reader);
            if (s.StartsWith(Prefix))
                s = s.Substring(Prefix.Length);
            return s;
        }
        public override bool CanConvert(Type objectType) { return objectType == typeof(MyClass); }
    }
    [JsonConverter(typeof(MyClassConverter))]
    public class MyClass
    {
        public string StringValue { get; set; }
    }
