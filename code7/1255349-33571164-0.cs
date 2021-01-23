    List<string> names = new List<string>();
    List<string> ids = new List<string>();
    JsonSerializer serializer = new JsonSerializer();
    using (StreamReader sr = new StreamReader("D:\\tweets.txt"))
    using (JsonTextReader reader = new JsonTextReader(sr))
    {
        reader.SupportMultipleContent = true;
        while (reader.Read())
        {
            if (reader.TokenType == JsonToken.StartObject)
            {
                JObject jo = JObject.Load(reader);
                names.Add((string)jo["Name"]);
                ids.Add((string)jo["Id"]);
            }
        }
    }
    Console.WriteLine("Names: " + string.Join(", ", names));
    Console.WriteLine("Ids: " + string.Join(", ", ids));
