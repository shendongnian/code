    using (var fs = File.OpenRead(path))
    using (var textReader = new StreamReader(fs))
    using (var reader = new JsonTextReader(textReader))
    {
        while (reader.Read())
        {
            if (reader.TokenType == JsonToken.StartObject)
            {
                var obj = JObject.Load(reader);
                Debug.WriteLine("{0} - {1}", obj["id"], obj["name"]);
            }
        }
    }
