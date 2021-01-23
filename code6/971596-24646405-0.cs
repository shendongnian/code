    public class ListofGuidJsonConverter : JsonConverter
    {
        private const string CapacityPropertyName = "c";
        private const string ListPropertyName = "l";
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(List<Guid>));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            int capacity = obj[CapacityPropertyName].Value<int>();
            List<Guid> list = new List<Guid>(capacity);
            foreach (JToken token in obj[ListPropertyName].Children())
            {
                list.Add(new Guid(token.ToString()));
            }
            return list;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            List<Guid> list = (List<Guid>)value;
            JObject obj = new JObject();
            obj.Add(CapacityPropertyName, list.Count);
            JArray array = new JArray();
            foreach (Guid guid in list)
            {
                array.Add(guid.ToString());
            }
            obj.Add(ListPropertyName, array);
            obj.WriteTo(writer);
        }
    }
