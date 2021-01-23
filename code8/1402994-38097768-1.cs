    public static byte[] Serialize(someType obj)
    {
        byte[] bytes = null;
    
        using (var stream = new MemoryStream())
        {
            using (var writer = new BinaryWriter(stream))
            {
                writer.Write(obj.X);
                writer.Write(obj.Y);
            }
    
            bytes = stream.ToArray();
        }
    
        return bytes;
    }
    
    public static someType Deserialize(byte[] data)
    {
        var obj = new someType();
    
        using (var stream = new MemoryStream(data))
        {
            using (var reader = new BinaryReader(stream))
            {
                obj.X = reader.ReadInt32();
                obj.Y = reader.ReadInt32();
            }
        }
    
        return obj;
    }
