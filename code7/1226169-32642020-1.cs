    public class FixMidnightDateTimeConverter : IsoDateTimeConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime?) || objectType == typeof(DateTime);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            Type type = (Nullable.GetUnderlyingType(objectType) ?? objectType);
            bool isNullable = (Nullable.GetUnderlyingType(objectType) != null);
            var token = JToken.Load(reader);
            if (token == null || token.Type == JTokenType.Null)
            {
                if (!isNullable)
                    throw new JsonSerializationException(string.Format("Null value for type {0} at path {1}", objectType.Name, reader.Path));
                return null;
            }
            // Fix strings like "2015-07-30T24:00:00Z"
            if (token.Type == JTokenType.String)
            {
                const string midnight = "T24:00:00Z";
                var str = ((string)token).Trim();
                if (str.EndsWith(midnight))
                {
                    var date = (DateTime?)(JValue)(str.Remove(str.Length - midnight.Length) + "T00:00:00Z");
                    if (date != null)
                    {
                        return date.Value.AddDays(1);
                    }
                }
            }
            using (var subReader = token.CreateReader())
            {
                while (subReader.TokenType == JsonToken.None)
                    subReader.Read();
                return base.ReadJson(subReader, objectType, existingValue, serializer); // Use base class to convert
            }
        }
    }
