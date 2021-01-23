    public class DateTimeConverter : IsoDateTimeConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime?);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var token = JToken.Load(reader);
            // For various JSON date formats, see
            // http://www.newtonsoft.com/json/help/html/DatesInJSON.htm
            // Try in JavaScript constructor format: new Date(1234656000000)
            if (token.Type == JTokenType.Constructor)
            {
                try
                {
                    var result = token.ToObject<DateTime?>(JsonSerializer.CreateDefault(new JsonSerializerSettings { Converters = new JsonConverter[] { new JavaScriptDateTimeConverter() } }));
                    if (result != null)
                        return result;
                }
                catch (JsonException)
                {
                }
            }
            // Try ISO format: "2009-02-15T00:00:00Z"
            if (token.Type == JTokenType.String)
            {
                try
                {
                    var result = token.ToObject<DateTime?>(JsonSerializer.CreateDefault(new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.IsoDateFormat }));
                    if (result != null)
                        return result;
                }
                catch (JsonException)
                {
                }
            }
            // Try Microsoft format: "\/Date(1234656000000)\/"
            if (token.Type == JTokenType.String)
            {
                try
                {
                    var result = token.ToObject<DateTime?>(JsonSerializer.CreateDefault(new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat }));
                    if (result != null)
                        return result;
                }
                catch (JsonException)
                {
                }
            }
            if (token.Type == JTokenType.String)
            {
                // Add other custom cases as required.
            }
            return null;
        }
    }
