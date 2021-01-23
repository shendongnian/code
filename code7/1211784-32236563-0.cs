    using (WebClient client = new WebClient())
    {
        using (StreamReader sr = new StreamReader(client.OpenRead(stringUrl)))
        {
            using (JsonReader reader = new JsonTextReader(sr))
            {
                JsonSerializer serializer = new JsonSerializer();
    
                // read the json from a stream
                // json size doesn't matter because only a small piece is read at a time from the HTTP request
                IList<Contact> result = serializer.Deserialize<List<Contact>>(reader);
            }
        }
    }
