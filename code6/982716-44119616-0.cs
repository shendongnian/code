    public static byte[] serialize(TBase obj)
    {
        var stream = new MemoryStream();
        TProtocol tProtocol = new TBinaryProtocol(new TStreamTransport(stream, stream));
        obj.Write(tProtocol);
        return stream.ToArray();
    }
    public static T deserialize<T>(byte[] data) where T : TBase, new()
    {
        T result = new T();
        var buffer = new TMemoryBuffer(data);
        TProtocol tProtocol = new TBinaryProtocol(buffer);
        result.Read(tProtocol);
        return result;
    }
