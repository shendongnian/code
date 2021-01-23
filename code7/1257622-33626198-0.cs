    public class GenericJsonConverter<TSourceType, TTargetType> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(TSourceType));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            return jo.ToObject<TTargetType>(serializer);
            return null;
        }
        public override bool CanWrite
        {
            get { return true; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value, typeof(TTargetType));
        }
    }
