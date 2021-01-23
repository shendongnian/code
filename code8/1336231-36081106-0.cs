    JsonSerializer serializer = new JsonSerializer();
    serializer.Converters.Add(new JavaScriptDateTimeConverter());
    serializer.NullValueHandling = NullValueHandling.Ignore;
    serializer.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
    serializer.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
    using (StreamWriter sw = new StreamWriter(fileName))
    {
        using (JsonWriter writer = new JsonTextWriter(sw))
        {
            serializer.Serialize(writer, dbObject);
        }
    }
