    public class ArrayItemAsObjectConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string[]);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            string[] items = (string[])value;
            writer.WriteStartArray();
            for (int i = 0; i < items.Length; i++)
            {
                writer.WriteStartObject();
                writer.WritePropertyName("name");
                writer.WriteValue(items[i]);
                writer.WriteEndObject();
            }
            writer.WriteEndArray();
        }
    }
    ///
    [JsonConverter(typeof(ArrayItemAsObjectConverter))]
    public string[] libraries { get; set; }
