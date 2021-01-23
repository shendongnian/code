        using (WebClient client = new WebClient())
        using (Stream stream = client.OpenRead(stringUrl))
        using (StreamReader streamReader = new StreamReader(stream))
        using (JsonTextReader reader = new JsonTextReader(streamReader))
        {
            reader.SupportMultipleContent = true;
            var serializer = new JsonSerializer();
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.StartObject)
                {
                    Contact c = serializer.Deserialize<Contact>(reader);
                    Console.WriteLine(c.FirstName + " " + c.LastName);
                }
            }
        }
