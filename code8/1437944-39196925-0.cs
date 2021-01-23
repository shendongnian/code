    public class EpochDateTimeConverter : DateTimeConverterBase
    {
        private static readonly DateTime Epoch = new DateTime(1970,1,1,0,0,0,DateTimeKind.Utc);
        
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }
            
            long millisecondsSinceEpoch;
            if (value is DateTime)
            {
                millisecondsSinceEpoch = Convert.ToInt64((((DateTime)value).ToUniversalTime() - Epoch).TotalMilliseconds);
            }
            else
            {
                if (!(value is DateTimeOffset))
                    throw new JsonSerializationException("Expected date object value.");
                millisecondsSinceEpoch = Convert.ToInt64((((DateTimeOffset)value).ToUniversalTime().UtcDateTime - Epoch).TotalMilliseconds);
            }
            writer.WriteValue(millisecondsSinceEpoch);
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                if (objectType != typeof(DateTime?) && objectType != typeof(DateTimeOffset?))
                    throw new JsonSerializationException($"Cannot convert null value to {objectType}");
                    
                return null;
            }
            if (reader.TokenType == JsonToken.Integer || reader.TokenType == JsonToken.Float)
            {
                var millisecondsSinceEpoch = (long)reader.Value;
                var dateTime = Epoch.AddMilliseconds(millisecondsSinceEpoch);
                if (objectType == typeof(DateTime) || objectType == typeof(DateTime?))
                {
                    return dateTime;
                }
                else
                {
                    return new DateTimeOffset(dateTime);
                }
            }
    
            throw new JsonSerializationException($"Cannot convert to DateTime or DateTimeOffset from token type {reader.TokenType}");
        }
    }
