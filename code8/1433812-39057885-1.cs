        var entity = new Entity();
        var formatter = new System.Net.Http.Formatting.JsonMediaTypeFormatter(); 
        // Or use GlobalConfiguration.Configuration.Formatters.JsonFormatter;
        var token = JToken.FromObject(entity, JsonSerializer.Create(formatter.SerializerSettings));
        HttpClient client = new HttpClient();
        var message = await client.PostAsJsonAsync("http://example.com", token);
        Console.WriteLine(message);
    This still leaves the dependency on global state inside serialization, which may cause problems later on.
