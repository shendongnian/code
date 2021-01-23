    class CustomConverter : JsonConverter
    {
        private HashSet<string> propertiesToSerialize;
        public CustomConverter(IEnumerable<string> propertiesToSerialize)
        {
            this.propertiesToSerialize = new HashSet<string>(propertiesToSerialize);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            foreach (PropertyInfo prop in value.GetType().GetProperties())
            {
                if (prop.CanRead && propertiesToSerialize.Contains(prop.Name))
                {
                    writer.WritePropertyName(prop.Name);
                    serializer.Serialize(writer, prop.GetValue(value));
                }
            }
            writer.WriteEndObject();
        }
        public override bool CanRead
        {
            get { return false; }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
