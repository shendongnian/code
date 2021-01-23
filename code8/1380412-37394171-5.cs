    private static readonly UTF8Encoding UTF8NoBOM = new UTF8Encoding(encoderShouldEmitUTF8Identifier:false, throwOnInvalidBytes:true);
    public void Serialize(Stream stream, object data)
    {
        var serializer = new Newtonsoft.Json.JsonSerializer();  
        using (var textWriter = new StreamWriter(stream, UTF8NoBOM, bufferSize:1024, leaveOpen:true))
        using (var jsonWriter = new JsonTextWriter(textWriter))
        {
            serializer.Serialize(jsonWriter, data);
        }
    }
