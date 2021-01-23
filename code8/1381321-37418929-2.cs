    class WrappedStringConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(string));
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            string s = (string)value;
            JObject jo = new JObject(new JProperty("value", s));
            jo.WriteTo(writer);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            return (string)jo["value"];
        }
    }
