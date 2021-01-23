    public static void SerializeObject<T>(T serializableObject, string fileName)
    {
        if (serializableObject == null) { return; }
        try
        {
            XmlSerializer serializer = new XmlSerializer(serializableObject.GetType());
            using (Stream stream = File.Open(fileName, FileMode.Create))
            {
                serializer.Serialize(stream, serializableObject);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
    public static T DeSerializeObject<T>(string fileName)
    {
        if (string.IsNullOrEmpty(fileName)) { return default(T); }
        try
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (Stream stream = File.Open(fileName, FileMode.Open))
            {
                return (T)serializer.Deserialize(stream);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return default(T);
    }
