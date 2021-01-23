    public static string ToXml<T>(this T value)
    {
        StringWriter stringWriter = new StringWriter();
        string xml;
        XmlSerializer xmlserializer = new XmlSerializer(typeof(T));
        using (XmlWriter writer = XmlWriter.Create(stringWriter, new XmlWriterSettings { Indent = true }))
        {
            writer.WriteStartDocument();
            xmlserializer.Serialize(writer, value);
            writer.WriteEndDocument();
            xml = stringWriter.ToString();
        }
        return xml;
    }
