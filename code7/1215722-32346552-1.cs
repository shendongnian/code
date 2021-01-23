    public static object Deserialize(byte[] data)
    {
        var binaryFormatter = new BinaryFormatter();
        return binaryFormatter.Deserialize(new MemoryStream(data));
    }
