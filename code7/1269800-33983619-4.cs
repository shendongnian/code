    public static T DeserializeObject<T>(string xml)
    {
        using (var ms = new MemoryStream())
        using (var writer = new StreamWriter(ms))
        {
            writer.Write(xml);
            ms.Position = 0;
    
            var serializer = new XmlSerializer(typeof(T));
            using (var reader = XmlReader.Create(ms))
                return (T)serializer.Deserialize(reader);
        }
    }
    var order = DeserializeObject<Order>(xmlOrder);
