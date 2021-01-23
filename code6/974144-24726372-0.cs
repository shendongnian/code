    public class DateTimeWithZoneConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (DateTimeWithZone) || objectType == typeof (DateTimeWithZone?);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var dtwz = (DateTimeWithZone) value;
            writer.WriteStartObject();
            writer.WritePropertyName("UniversalTime");
            serializer.Serialize(writer, dtwz.UniversalTime);
            writer.WritePropertyName("TimeZone");
            serializer.Serialize(writer, dtwz.TimeZone.Id);
            writer.WriteEndObject();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var ut = default(DateTime);
            var tz = default(TimeZoneInfo);
            var gotUniversalTime = false;
            var gotTimeZone = false;
            while (reader.Read())
            {
                if (reader.TokenType != JsonToken.PropertyName)
                    break;
                var propertyName = (string)reader.Value;
                if (!reader.Read())
                    continue;
                if (propertyName == "UniversalTime")
                {
                    ut = serializer.Deserialize<DateTime>(reader);
                    gotUniversalTime = true;
                }
                if (propertyName == "TimeZone")
                {
                    var tzid = serializer.Deserialize<string>(reader);
                    tz = TimeZoneInfo.FindSystemTimeZoneById(tzid);
                    gotTimeZone = true;
                }
            }
            if (!(gotUniversalTime && gotTimeZone))
            {
                throw new InvalidDataException("An DateTimeWithZone must contain UniversalTime and TimeZone properties.");
            }
            return new DateTimeWithZone(ut, tz);
        }
    }
