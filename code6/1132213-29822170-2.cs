    public class BarAJsonConverter : BarBaseJsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // '$type' property will be added because used serializer has TypeNameHandling = TypeNameHandling.Objects
            GetSerializer().Serialize(writer, value);
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var existingJObj = existingValue as JObject;
            if (existingJObj != null)
            {
                return existingJObj.ToObject<BarA>(GetSerializer());
            }
    
            throw new NotImplementedException();
        }
    
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(BarA);
        }
    }
