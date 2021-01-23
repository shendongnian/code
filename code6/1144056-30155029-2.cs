    public class CacheItemConverter : CustomCreationConverter<CacheItem<object>>
    {
        public override CacheItem<object> Create(Type objectType)
        {
            return new CacheItem<object>();
        }
    
        public CacheItem<object> Create(Type objectType, JObject jObject)
        {
            var keyProperty = jObject.Property("Key");
            if (keyProperty == null)
                throw new ArgumentException("Key missing.");
    
            var result = new CacheItem<object>();
    
            var keyValue = keyProperty.First.Value<string>();
            if (keyValue.Equals("readbilitySettings", StringComparison.InvariantCultureIgnoreCase))
                result.Value = new ReadabilitySettings();
            else
                throw new ArgumentException(string.Format("Unsupported key {0}", keyValue));
    
            return result;
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            var target = Create(objectType, jObject);
            serializer.Populate(jObject.CreateReader(), target);
            /* Here your JSON is deserialised and mapped to your object */
    
            return target;
        }
    }
