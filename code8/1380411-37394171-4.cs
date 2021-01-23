    public void Serialize(Stream stream, object data)
    {
        var serializer = new Newtonsoft.Json.JsonSerializer();  
        using (var textWriter = new StreamWriter(new DisposeBlocker(stream)))
        using (var jsonWriter = new JsonTextWriter(textWriter))
        {
            serializer.Serialize(jsonWriter, data);
        }
    }
