    // Set up The Json Media Type Formatter
    var JsonMTF = new JsonMediaTypeFormatter
    {
      SerializerSettings = { MissingMemberHandling = MissingMemberHandling.Error }
    };
    
    // Clear all formatters
    config.Formatters.Clear();
    // Add the JSON formatter
    config.Formatters.Add(JsonMTF);
