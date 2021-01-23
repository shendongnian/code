    public static string ToXml<T>(this T obj, string rootName)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(rootName));
        var xmlNs = new XmlSerializerNamespaces();
        xmlNs.Add(string.Empty, string.Empty);
        using (StringWriter sw = new StringWriter())
        {
            serializer.Serialize(sw, obj, xmlNs);
            return sw.ToString();
        }
    }
