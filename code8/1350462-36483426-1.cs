    var settings = new JsonSerializerSettings { DateParseHandling = DateParseHandling.None };
    var sb = new StringBuilder();
    using (var writer = new StringWriter(sb))
    using (var jsonWriter = new DateLiteralJsonTextWriter(writer) { Formatting = Formatting.Indented})
    {
        JsonSerializer.CreateDefault(settings).Serialize(jsonWriter,  JsonConvert.DeserializeObject(extract, settings));
    }
    Console.WriteLine(sb);
