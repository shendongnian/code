    public class FakeArrayToNullConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return false;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Array)
            {
                return null;
            }
            return  token.ToObject<T>() ;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
