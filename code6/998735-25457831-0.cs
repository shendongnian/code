    public class BaseTypeConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JObject obj = new JObject();
            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
                if (prop.CanRead)
                {
                    obj.Add(prop.Name, JToken.FromObject(prop.GetValue(value)));
                }
            }
            obj.WriteTo(writer);
        }
        public override bool CanRead
        {
            get { return false; }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
