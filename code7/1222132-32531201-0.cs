    var json = "{ \"$ref\": \"THIS IS DATA, NOT A JSON.NET REFERENCE\", \"other\": \"other\" }";
    var jObj = JObject.Parse(json);
    jObj.Descendants()
        .OfType<JProperty>()
        .Where(p => p.Name == "$ref")
        .ToList()
        .ForEach(p => p.Replace(new JProperty("Ref", p.Value)));
    var deserialized =  jObj.ToObject<MyType>();
            
    Console.WriteLine(deserialized.Ref);
