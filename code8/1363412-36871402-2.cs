    var settings = new JsonSerializerSettings
    {
        Formatting = Newtonsoft.Json.Formatting.Indented,
        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        PreserveReferencesHandling = PreserveReferencesHandling.All,
        ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
    };
    var deserialized = JsonConvert.DeserializeObject<Root>(json, settings);
