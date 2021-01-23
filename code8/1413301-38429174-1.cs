    string json = @"{""name"": ""John""}{""name"": ""Joe""}";
    using (StringReader sr = new StringReader(json))
    using (JsonTextReader reader = new JsonTextReader(sr))
    {
        reader.SupportMultipleContent = true;
        var serializer = new JsonSerializer();
        while (reader.Read())
        {
            if (reader.TokenType == JsonToken.StartObject)
            {
                Person p = serializer.Deserialize<Person>(reader);
                Console.WriteLine(p.Name);
            }
        }
    }
