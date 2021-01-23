    public static T Deserialize<T>(string json)
    {
        using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            return (T)serializer.ReadObject(ms);
        } 
    }
