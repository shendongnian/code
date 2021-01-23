    serverResponse = serverResponse.Replace("\"", "");
    using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(serverResponse)))
    {
         return Serializer.Deserialize<User>(ms);
    }
