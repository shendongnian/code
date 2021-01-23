    var settings = new JsonSerializerSettings()
    {
        TypeNameHandling = TypeNameHandling.Auto,
        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        Formatting = Formatting.Indented
    };
    // important bit:
     settings.Converters.Add(new FSharpOptionConverter());
