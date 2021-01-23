        private class PropertyNamesSerializer : JsonConverter
        {
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                writer.WriteStartObject();
                writer.WritePropertyName("name");
                writer.WriteValue("setParameterValues");
                writer.WritePropertyName("parameterValues");
                writer.WriteStartArray();
                writer.WriteStartObject();
                foreach (var property in value.GetType().GetProperties())
                {
                    var attribute = property.GetCustomAttribute<JsonPropertyAttribute>();
                    writer.WritePropertyName(attribute.PropertyName);
                    writer.WriteValue(property.GetValue(value));
                }
                writer.WriteEndObject();
                writer.WriteEndArray();
                writer.WriteEndObject();
            }
        // other methods
