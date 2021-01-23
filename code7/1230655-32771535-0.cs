    public static class JsonExtensions
    {
        public static string ToString(this JToken token, Formatting formatting = Formatting.Indented, JsonSerializerSettings settings = null)
        {
            using (var sw = new StringWriter(CultureInfo.InvariantCulture))
            {
                using (var jsonWriter = new JsonTextWriter(sw))
                {
                    jsonWriter.Formatting = formatting;
                    jsonWriter.Culture = CultureInfo.InvariantCulture;
                    if (settings != null)
                    {
                        jsonWriter.DateFormatHandling = settings.DateFormatHandling;
                        jsonWriter.DateFormatString = settings.DateFormatString;
                        jsonWriter.DateTimeZoneHandling = settings.DateTimeZoneHandling;
                        jsonWriter.FloatFormatHandling = settings.FloatFormatHandling;
                        jsonWriter.StringEscapeHandling = settings.StringEscapeHandling;
                    }
                    token.WriteTo(jsonWriter);
                }
                return sw.ToString();
            }
        }
    }
