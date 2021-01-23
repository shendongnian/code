    public static byte[] SerializeBson<T>(T obj)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            using (BsonWriter writer = new BsonWriter(ms))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, obj);
            }
            return ms.ToArray();
        }
    }
