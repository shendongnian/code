    class Program {
        static void Main(string[] args) {
            var referenceData = new ReferenceData() {
                Data = new List<DataItem>() {
                    new DataItem(){
                        Item = new Dictionary<string,string>()  {
                            {"ShortDescription", "Lorem ipssumm"},
                            {"Title", "some text"},
                            {"PlanType", "ZEROP"},
                        }
                    },
                    new DataItem(){
                        Item = new Dictionary<string,string>()  {
                            {"ShortDescription", "Lorem ipssumm"},
                            {"Title", "some text"},
                            {"PlanType", "ZEROP"},
                        }
                    },
                    new DataItem(){
                        Item = new Dictionary<string,string>()  {
                            {"ShortDescription", "Lorem ipssumm"},
                            {"Title", "some text"},
                            {"PlanType", "ZEROP"},
                        }
                    }
                }
            };
            var settings = new JsonSerializerSettings {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore,
                Converters = new List<JsonConverter>() { new KeyValuePairConverter(), new CustomJsonSerializableConverter() }
            };
            File.WriteAllText("hello.json", Newtonsoft.Json.JsonConvert.SerializeObject(
                referenceData,
                Formatting.Indented,
                settings
            ));
        }
    }
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
            DataItem result = new DataItem();
            result.Item = serializer.Deserialize<Dictionary<string, string>>(reader);
            return result;
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
