    JsonSerializerSettings settings = new JsonSerializerSettings
    {
        PreserveReferencesHandling = PreserveReferencesHandling.Objects,
        Formatting = Formatting.Indented,
        Converters = new List<JsonConverter> { new IsoDateTimeConverter() }
    }
    var json = JsonConvert.SerializeObject(myObject, settings);
