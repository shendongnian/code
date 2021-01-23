    public class ActivityTypeConverter : StringEnumConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            bool isNullable = (Nullable.GetUnderlyingType(objectType) != null);
            Type type = (Nullable.GetUnderlyingType(objectType) ?? objectType);
            if (reader.TokenType == JsonToken.Null)
            {
                if (!isNullable)
                    throw new JsonSerializationException();
                return null;
            }
            var token = JToken.Load(reader);
            if (token.Type == JTokenType.String)
            {
                var rawString = ((string)token).ToLower();
                if (rawString.Contains("click"))
                    return ActivityType.LinkClick;
                else if (rawString.Contains("salesforce"))
                    return ActivityType.Salesforce;
                else if (rawString.Contains("email_open"))
                    return ActivityType.EmailOpen;
            }
            using (var subReader = token.CreateReader())
            {
                while (subReader.TokenType == JsonToken.None)
                    subReader.Read();
                try
                {
                    return base.ReadJson(subReader, objectType, existingValue, serializer); // Use base class to convert
                }
                catch (Exception ex)
                {
                    return ActivityType.Unsupported;
                }
            }
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ActivityType);
        }
    }
