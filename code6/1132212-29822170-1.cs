    public class BarConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObj = JObject.Load(reader);
            var type = jObj.Value<string>("$type");
    
            if (type == GetTypeString<BarA>())
            {
                return new BarAJsonConverter().ReadJson(reader, objectType, jObj, serializer);
            }
            // Other implementations if IBar
    
            throw new NotSupportedException();
        }
    
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (IBar);
        }
    
        public override bool CanWrite
        {
            get { return false; }
        }
    
        private string GetTypeString<T>()
        {
            var typeOfT = typeof (T);
            return string.Format("{0}, {1}", typeOfT.FullName, typeOfT.Assembly.GetName().Name);
        }
    }
