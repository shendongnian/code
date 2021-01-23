    public class JavaScriptYMDDateTimeConverter : JavaScriptDateTimeConverter
    {
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
            if (token.Type != JTokenType.Constructor)
            {
                throw new JsonSerializationException(string.Format("Invalid Date constructor \"{0}\" at path {1}", token.ToString(), reader.Path));
            }
            var constructor = (JConstructor)token;
            if (!string.Equals(constructor.Name, "Date", StringComparison.Ordinal))
            {
                throw new JsonSerializationException(string.Format("Invalid Date constructor \"{0}\" at path {1}", token.ToString(), reader.Path));
            }
            var values = constructor.Values().ToArray();
            if (values.Length == 0)
            {
                throw new JsonSerializationException(string.Format("Invalid Date constructor \"{0}\" at path {1}", token.ToString(), reader.Path));
            }
            else if (values.Length == 1)
            {
                // Assume ticks
                using (var subReader = constructor.CreateReader())
                {
                    while (subReader.TokenType != JsonToken.StartConstructor)
                        subReader.Read();
                    return base.ReadJson(subReader, objectType, existingValue, serializer); // Use base class to convert
                }
            }
            else
            {
                var year = (values.Length > 0 ? (int)values[0] : 0);
                var month = (values.Length > 1 ? (int)values[1] : 0) + 1; // c# months go from 1 to 12, JavaScript from 0 to 11
                var day = (values.Length > 2 ? (int)values[2] : 0);
                var hour = (values.Length > 3 ? (int)values[3] : 0);
                var min = (values.Length > 4 ? (int)values[4] : 0);
                var sec = (values.Length > 5 ? (int)values[5] : 0);
                var ms = (values.Length > 6 ? (int)values[6] : 0);
                var dt = new DateTime(year, month, day, hour, min, sec, DateTimeKind.Utc);
                if (type == typeof(DateTimeOffset))
                    return new DateTimeOffset(dt);
                return dt;
            }
        }
    }
