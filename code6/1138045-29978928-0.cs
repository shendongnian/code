    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var list = value as List<ItemClass>;
        writer.WriteStartObject();           // << Added
        writer.WritePropertyName("items");   // << Added
        writer.WriteStartArray();
        foreach (var item in list)
        {
            writer.WriteStartObject();
            writer.WritePropertyName(item.Id);
            writer.WriteStartObject();
            writer.WritePropertyName("data");
            writer.WriteValue(item.Data);
            //writer.WriteEndObject();       // << Removed
            //writer.WriteStartObject();     // << Removed
            writer.WritePropertyName("description");
            writer.WriteValue(item.Description);
            writer.WriteEndObject();
            writer.WriteEndObject();
        }
        writer.WriteEndArray();
        writer.WriteEndObject();             // << Added
    }
