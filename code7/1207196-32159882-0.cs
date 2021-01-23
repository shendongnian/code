    class DateAndCountConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(DateAndCount));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            DateAndCount dac = new DateAndCount();
            dac.Date = (DateTime?)jo["Date"];
            // put the value of the first integer property from the JSON into Count
            dac.Count = (int)jo.Properties().First(p => p.Value.Type == JTokenType.Integer).Value;
            return dac;
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
