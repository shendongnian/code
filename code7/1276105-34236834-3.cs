    public static T Deserialize<T>(string json)
    {
        var bytes = Encoding.Unicode.GetBytes(json);
        using (var ms = new MemoryStream(bytes))
        {
            var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(T));
            return (T)serializer.ReadObject(ms);
        }
    }
