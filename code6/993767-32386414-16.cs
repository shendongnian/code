    public string Serialize(MyData data)
    {
        // _serializer is an instance field of type JsonSerializer
        return _serializer.Serialize(data).ToString();
    }
    public MyData Deserialize(Stream stream)
    {
        var json = JsonValue.Parse(stream);
        return _serializer.Deserialize<MyData>(json);
    }
