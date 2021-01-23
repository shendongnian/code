    public static object DeserializeObject(string value, Type type, params JsonConverter[] converters)
    {
      JsonSerializerSettings serializerSettings;
      if (converters == null || converters.Length <= 0)
        serializerSettings = (JsonSerializerSettings) null;
      else
        serializerSettings = new JsonSerializerSettings()
        {
          Converters = (IList<JsonConverter>) converters
        };
      JsonSerializerSettings settings = serializerSettings;
      return JsonConvert.DeserializeObject(value, type, settings);
    }
    public static object DeserializeObject(string value, Type type, JsonSerializerSettings settings)
    {
      ValidationUtils.ArgumentNotNull((object) value, "value");
      JsonSerializer @default = JsonSerializer.CreateDefault(settings);
      if (!@default.IsCheckAdditionalContentSet())
        @default.CheckAdditionalContent = true;
      using (JsonTextReader jsonTextReader = new JsonTextReader((TextReader) new StringReader(value)))
        return @default.Deserialize((JsonReader) jsonTextReader, type);
    }
