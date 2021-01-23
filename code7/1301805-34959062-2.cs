    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        StringBuilder sb = new StringBuilder();
        using (var innerWriter = new NullJsonWriter(new StringWriter(sb))
        {
            innerWriter.WriteStartObject();
            
            // ... (snip) ...
            
            innerWriter.WriteEndObject();
        }
        writer.WriteRawValue(sb.ToString());
    }
