    public class CustomConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            your code ..
        }
     
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            //explicitly specify the concrete type we want to create
            return serializer.Deserialize<T>(reader);
        }
     
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            your code ...
        }
    }
