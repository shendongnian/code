    class BadDateFixingConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(DateTime) || objectType == typeof(DateTime?));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string rawDate = (string)reader.Value;
            DateTime date;
            
            // First try to parse the date string as is (in case it is correctly formatted)
            if (DateTime.TryParse(rawDate, out date))
            {
                return date;
            }
            
            // If not, see if the string matches the known bad format. 
            // If so, replace the ':' with '.' and reparse.
            if (rawDate.Length > 19 && rawDate[19] == ':')
            {
                rawDate = rawDate.Substring(0, 19) + '.' + rawDate.Substring(20);
                if (DateTime.TryParse(rawDate, out date))
                {
                    return date;
                }
            }
            // It's not a date after all, so just return the default value
            if (objectType == typeof(DateTime?)) 
                return null;
            return DateTime.MinValue;
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
