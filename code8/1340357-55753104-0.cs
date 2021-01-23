    public static string SerializeObject(object value, Type type, JsonSerializerSettings settings)
    {
        JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(settings);
        return SerializeObjectInternal(value, type, jsonSerializer);
    }
