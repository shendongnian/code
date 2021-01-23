    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.StartObject)
        {
            return ReadRegexObject(reader, serializer);
        }
        if (reader.TokenType == JsonToken.String)
        {
            return ReadRegexString(reader);
        }
        throw JsonSerializationException.Create(reader, "Unexpected token when reading Regex.");
    }
