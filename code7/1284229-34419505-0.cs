    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        if (reader.ValueType == typeof(string))
        {
            return DateTime.Parse((string)reader.Value);
        }
        else if (reader.ValueType == typeof(long))
        {
            return new DateTime(1970, 1, 1).AddMilliseconds((long)reader.Value);
        }
        throw new NotSupportedException();
    }
