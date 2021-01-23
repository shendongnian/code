       public class UtcDateTimeOffsetConverter : Newtonsoft.Json.Converters.IsoDateTimeConverter
        {
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                if (value is Iso8601SerializableDateTimeOffset)
                {
                    var date = (Iso8601SerializableDateTimeOffset)value;
                    value = date.value;
                }
                base.WriteJson(writer, value, serializer);
            }
    
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                object value = base.ReadJson(reader, objectType, existingValue, serializer);
                if (value is Iso8601SerializableDateTimeOffset)
                {
                    var date = (Iso8601SerializableDateTimeOffset)value;
                    value = date.value;
                }
                return value;
            }
        }
