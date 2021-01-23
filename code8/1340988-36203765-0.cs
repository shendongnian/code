    class MetadataConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Metadata));
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JArray array = new JArray();
            foreach (PropertyInfo pi in value.GetType().GetProperties().Where(p => p.CanRead))
            {
                array.Add(new JObject(new JProperty(pi.Name, pi.GetValue(value, null))));
            }
            JObject obj = new JObject(new JProperty("td", array));
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
