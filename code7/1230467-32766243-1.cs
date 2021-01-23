    public static void Serialize<T>(string path, T value)
    {
        System.Xml.Serialization.XmlSerializer serializer = 
                     new System.Xml.Serialization.XmlSerializer(typeof(T));
        System.Xml.XmlTextWriter writer = 
                     new System.Xml.XmlTextWriter(path, System.Text.Encoding.UTF8);
        serializer.Serialize(writer, value);
        writer.Close();
    }
