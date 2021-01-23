    public class JavaArrayConverter : JsonConverter
    {
        Type _Type = null;
        public override bool CanConvert(Type objectType)
        {
            if(objectType.IsGenericType)
            {
                _Type = typeof(List<>).MakeGenericType(objectType.GetGenericArguments()[0]);
                return objectType == _Type;
            }
            return false;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jArray = JArray.Load(reader);
            return jArray[1].ToObject(_Type);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
