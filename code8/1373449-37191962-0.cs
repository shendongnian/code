    public class CustomDictionaryConverter<K, V> : JsonConverter
    {
        private string KeyPropertyName { get; set; }
        private string ValuePropertyName { get; set; }
        public CustomDictionaryConverter(string keyPropertyName, string valuePropertyName)
        {
            KeyPropertyName = keyPropertyName;
            ValuePropertyName = valuePropertyName;
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof(IDictionary<K, V>).IsAssignableFrom(objectType);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            IDictionary<K, V> dict = (IDictionary<K, V>)value;
            JArray array = new JArray();
            foreach (var kvp in dict)
            {
                JObject obj = new JObject();
                obj.Add(KeyPropertyName, JToken.FromObject(kvp.Key, serializer));
                obj.Add(ValuePropertyName, JToken.FromObject(kvp.Value, serializer));
                array.Add(obj);
            }
            array.WriteTo(writer);
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
