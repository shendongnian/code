    string json = @"{""name"": ""John""}{""name"": ""Joe""}";
    using (StringReader streamReader = new StringReader(json))
    using (JsonTextReader reader = new JsonTextReader(streamReader))
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
