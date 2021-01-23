    private T Deserializer<T>()
    {
        T instance = null;
        try
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            using (var stringreader = new StringReader(somestring))
            {
                instance = (T)xmlSerializer.Deserialize(stringreader);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    
        return instance;
    } 
