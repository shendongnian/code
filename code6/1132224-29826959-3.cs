    public class WrappedJsonConverter<T> : JsonConverter<T> where T : class
    {        
        private static bool _canWrite = true;
        private static bool _canRead = true;
        public override bool CanWrite
        {
            get
            {
                if (_canWrite)
                    return true;
                _canWrite = true;
                return false;
            }
        }
        public override bool CanRead
        {
            get
            {
                if (_canRead)
                    return true;
                _canRead = true;
                return false;
            }
        }
        public override T ReadJson(JsonReader reader, T existingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            JToken token;
            T value;
            if (!jsonObject.TryGetValue("$wrappedType", out token))
            {
                //The static _canRead is a terrible hack to get around the serialization loop...
                _canRead = false;
                value = jsonObject.ToObject<T>(serializer);
                _canRead = true;
                return value;
            }
            var typeName = jsonObject.GetValue("$wrappedType").Value<string>();
            
            var type = JsonExtensions.GetTypeFromJsonTypeName(typeName, serializer.Binder);
            
            var converter = serializer.Converters.FirstOrDefault(c => c.CanConvert(type) && c.CanRead);
            var wrappedObjectReader = jsonObject.GetValue("$wrappedValue").CreateReader();
            wrappedObjectReader.Read();
            if (converter == null)
            {
                _canRead = false;
                value = (T)serializer.Deserialize(wrappedObjectReader, type);
                _canRead = true;
            }
            else
            {
                value = (T)converter.ReadJson(wrappedObjectReader, type, existingValue, serializer);
            }
            return value;
        }
        public override void WriteJson(JsonWriter writer, T value, JsonSerializer serializer)
        {
            var type = value.GetType();
            var converter = serializer.Converters.FirstOrDefault(c => c.CanConvert(type) && c.CanWrite);
            if (converter == null)
            {
                //This is a terrible hack to get around the serialization loop...
                _canWrite = false;
                serializer.Serialize(writer, value, type);
                _canWrite = true;
                return;
            }
            writer.WriteStartObject();
            {
                writer.WritePropertyName("$wrappedType");
                writer.WriteValue(type.GetJsonSimpleTypeName());
                writer.WritePropertyName("$wrappedValue");
                converter.WriteJson(writer, value, serializer);
            }
            writer.WriteEndObject();
        }
    }
