    public static class DataContractSerializerHelper
    {
        public static string GetXml<T>(T obj, DataContractSerializer serializer)
        {
            using (var textWriter = new StringWriter())
            {
                var settings = new XmlWriterSettings { Indent = true, IndentChars = "    " };
                using (var xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                    serializer.WriteObject(xmlWriter, obj);
                }
                return textWriter.ToString();
            }
        }
        public static string GetXml<T>(T obj)
        {
            var serializer = new DataContractSerializer(typeof(T));
            return GetXml(obj, serializer);
        }
    }
