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
                throw new JsonSerializationException(string.Format("Invalid DateTime constructor \"{0}\" at path {1}", token.ToString(), reader.Path));
            }
            var constructor = (JConstructor)token;
            var values = constructor.Values().ToArray();
            DateTime dt;
            if (values.Length == 1)
            {
                // Assume ticks
                dt = JsonConvert.DeserializeObject<DateTime>(token.ToString(), new JsonSerializerSettings { Converters = new JsonConverter[] { new JavaScriptDateTimeConverter() } });
            }
            else
            {
                var year = (values.Length > 0 ? (int)values[0] : 0);
                var month = (values.Length > 1 ? (int)values[1] : 0);
                var day = (values.Length > 2 ? (int)values[2] : 0);
                var hour = (values.Length > 3 ? (int)values[3] : 0);
                var min = (values.Length > 4 ? (int)values[4] : 0);
                var sec = (values.Length > 5 ? (int)values[5] : 0);
                dt = new DateTime(year, month, day, hour, min, sec, DateTimeKind.Utc);
            }
            if (type == typeof(DateTimeOffset))
                return new DateTimeOffset(dt);
            return dt;
        }
    }
