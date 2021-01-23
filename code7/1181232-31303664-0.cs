        public static class JsonExtensions
        {
            public static string SerializeObjectNoDefaultSettings(object value, Formatting formatting, JsonSerializerSettings settings)
            {
                var jsonSerializer = JsonSerializer.Create(settings);
                jsonSerializer.Formatting = formatting;
                StringBuilder sb = new StringBuilder(256);
                StringWriter sw = new StringWriter(sb, CultureInfo.InvariantCulture);
                using (JsonTextWriter jsonWriter = new JsonTextWriter(sw))
                {
                    jsonWriter.Formatting = jsonSerializer.Formatting;
                    jsonSerializer.Serialize(jsonWriter, value);
                }
                return sw.ToString(); 
            }
        }
    And then use it like:
        var json = JsonExtensions.SerializeObjectNoDefaultSettings(value, Formatting.None, new JsonSerializerSettings());
