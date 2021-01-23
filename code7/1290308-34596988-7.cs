    public static string ToXml<T>(this T obj)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        using (StringWriter sw = new StringWriter())
        {
            serializer.Serialize(sw, obj);
            return sw.ToString();
        }
    }
