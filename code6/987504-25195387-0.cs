    class StatisticConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Statistic));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JArray array = JArray.Load(reader);
            return new Statistic
            {
                ProjectDate = DateTime.ParseExact(array[0].ToString(), "yyyyMMdd", 
                                System.Globalization.CultureInfo.InvariantCulture),
                Sale = array[1].ToObject<decimal>()
            };
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
