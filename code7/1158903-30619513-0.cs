    public class ReferenceData {
        public string Version { get; set; }
        public List<DataItem> Data { get; set; }
    }
    [CustomJsonSerializable]
    public class DataItem {
        public Dictionary<string, string> Item { get; set; }
        public static void WriteJson(JsonWriter writer, DataItem value, JsonSerializer serializer) {
            serializer.Serialize(writer, value.Item);
        }
        public static DataItem ReadJson(JsonReader reader, DataItem existingValue, JsonSerializer serializer) {
            existingValue.Item = serializer.Deserialize<Dictionary<string, string>>(reader);
            return existingValue;
        }
    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class CustomJsonSerializableAttribute : Attribute {
        public readonly string Read;
        public readonly string Write;
        public CustomJsonSerializableAttribute()
            : this(null, null) {
        }
        public CustomJsonSerializableAttribute(string read, string write) {
            this.Read = read;
            this.Write = write;
        }
    }
    public class CustomJsonSerializableConverter : JsonConverter {
        public override bool CanConvert(Type objectType) {
            return objectType.GetCustomAttribute(typeof(CustomJsonSerializableAttribute), false) != null;
        }
        public override bool CanWrite {
            get {
                return true;
            }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            if(value != null) {
                var t = value.GetType();
                var attr = (CustomJsonSerializableAttribute)t.GetCustomAttribute(typeof(CustomJsonSerializableAttribute), false);
                var @delegate = t.GetMethod(attr.Write ?? "WriteJson", new Type[] { typeof(JsonWriter), t, typeof(JsonSerializer) });
                @delegate.Invoke(null, new object[] { writer, value, serializer });
            } else {
                serializer.Serialize(writer, null);
            }
        }
        public override bool CanRead {
            get {
                return true;
            }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            var t = existingValue.GetType();
            var attr = (CustomJsonSerializableAttribute)t.GetCustomAttribute(typeof(CustomJsonSerializableAttribute), false);
            var @delegate = t.GetMethod(attr.Read ?? "ReadJson", new Type[] { typeof(JsonReader), t, typeof(JsonSerializer) });
            return @delegate.Invoke(null, new object[] { reader, existingValue, serializer });
        }
    }
