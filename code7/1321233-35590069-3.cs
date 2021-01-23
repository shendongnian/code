    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        if (reader.Value != null && reader.ValueType == typeof(string))
        {
            return someSpecialDataTypeInstance;
        }
        else if (reader.TokenType == JsonToken.StartObject)
        {
            existingValue = existingValue ?? serializer.ContractResolver.ResolveContract(objectType).DefaultCreator();
            serializer.Populate(reader, existingValue);
            return existingValue;
        }
        else if (reader.TokenType == JsonToken.Null)
        {
            return null;
        }
        else
        {
            throw new JsonSerializationException();
        }
    }
