    public static class XmlSerializationHelper
    {
        public static string GetXml<X>(this X toSerialize, XmlSerializer serializer = null, XmlSerializerNamespaces namespaces = null, Encoding encoding = null)
        {
            if (toSerialize == null)
                throw new ArgumentNullException();
            encoding = encoding ?? Encoding.UTF8;
            serializer = serializer ?? new XmlSerializer(toSerialize.GetType());
            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(stream, encoding))
            {
                serializer.Serialize(writer, toSerialize, namespaces);
                writer.Flush();
                stream.Position = 0;
                using (var reader = new StreamReader(stream, encoding))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
