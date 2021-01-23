    public class ComplexDictionaryConverter<K,V> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDictionary<K,V>)));
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JObject obj = new JObject();
            foreach (PropertyInfo prop in GetReadWriteProperties(value.GetType()))
            {
                object val = prop.GetValue(value);
                obj.Add(prop.Name, val != null ? JToken.FromObject(val, serializer) : new JValue(val));
            }
            JArray array = new JArray();
            foreach (var kvp in (IDictionary<K, V>)value)
            {
                JObject item = new JObject();
                item.Add("Key", JToken.FromObject(kvp.Key, serializer));
                item.Add("Value", kvp.Value != null ? JToken.FromObject(kvp.Value, serializer) : new JValue(kvp.Value));
                array.Add(item);
            }
            obj.Add("KVPs", array);
            obj.WriteTo(writer);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            IDictionary<K, V> dict = (IDictionary<K, V>)Activator.CreateInstance(objectType);
            foreach (PropertyInfo prop in GetReadWriteProperties(objectType))
            {
                JToken token = obj[prop.Name];
                object val = token != null ? token.ToObject(prop.PropertyType, serializer) : null;
                prop.SetValue(dict, val);
            }
            JArray array = (JArray)obj["KVPs"];
            foreach (JObject kvp in array.Children<JObject>())
            {
                K key = kvp["Key"].ToObject<K>(serializer);
                V val = kvp["Value"].ToObject<V>(serializer);
                dict.Add(key, val);
            }
            return dict;
        }
        private IEnumerable<PropertyInfo> GetReadWriteProperties(Type type)
        {
            return type.GetProperties().Where(p => p.CanRead && p.CanWrite && !p.GetIndexParameters().Any());
        }
    }
