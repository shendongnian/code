    public static string Serialize<T>(T item)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        using (StringWriter stringWriter = new StringWriter())
        {
            using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { Indent = true, OmitXmlDeclaration = true }))
            {
                serializer.Serialize(xmlWriter, item, new XmlSerializerNamespaces(new[] { new XmlQualifiedName(string.Empty, string.Empty) }));
            }
            return stringWriter.ToString();
        }
    }
