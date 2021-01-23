    class BadDateFixingConverter : JsonConverter
    {
        string FormatStringVaue;
        public BadDateFixingConverter(string FormatString)
        {
            this.FormatStringVaue = FormatString;
        }
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(DateTime) || objectType == typeof(DateTime?));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string rawDate = (string)reader.Value;
            try
            {
                return DateTime.ParseExact(rawDate, FormatStringVaue, null);
            }
            catch
            {
                // It's not a date after all, so just return the default value
                if (objectType == typeof(DateTime?))
                    return null;
                return DateTime.MinValue;
            }
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
