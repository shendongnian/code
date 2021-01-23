    //using System.Xml.Serialization;
    public static string SerializeToXml<T>(T data, bool isMinified = true)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        StringWriter sw = new StringWriter();
        serializer.Serialize(sw, data);
        var xmlString = sw.ToString();
        return xmlString;
    }
