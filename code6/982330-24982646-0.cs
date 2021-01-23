    class IdOnlyListConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (typeof(IEnumerable).IsAssignableFrom(objectType) && 
                    objectType != typeof(string));
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JArray array = new JArray();
            foreach (object item in (IEnumerable)value)
            {
                PropertyInfo idProp = item.GetType().GetProperty("id");
                if (idProp != null && idProp.CanRead)
                {
                    array.Add(JToken.FromObject(idProp.GetValue(item, null)));
                }
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
