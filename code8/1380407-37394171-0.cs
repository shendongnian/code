    public void Serialize(Stream stream, object data)
    {
        var serializer = new Newtonsoft.Json.JsonSerializer();  
        using (var textWriter = new StreamWriter(stream, Encoding.UTF8, bufferSize:1024, leaveOpen:true))
        using (var jsonWriter = new JsonTextWriter(textWriter))
        {
            serializer.Serialize(jsonWriter, data);
        }
    }
