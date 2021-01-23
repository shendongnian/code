    public void SerializeObject<T>(T serializableObject, string fileName)
    {
        if (serializableObject == null) return;
    
        var serializer = new XmlSerializer(serializableObject.GetType());
    
        using (var stream = File.Open(fileName, FileMode.Create))
        {
            serializer.Serialize(stream, serializableObject);
        }
    }
        
    public T DeserializeObject<T>(string fileName)
    {
        if (string.IsNullOrEmpty(fileName)) return default(T);
    
        var serializer = new XmlSerializer(typeof(T));
    
        using (var stream = File.Open(fileName, FileMode.Open))
        {            
            return (T) serializer.Deserialize(stream);
        }
    }
