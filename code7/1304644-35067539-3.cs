    namespace StackOverflow
    {
        public class XmlSerializerHelper<T> where T : class
        {
            private readonly XmlSerializer _serializer;
    
            public XmlSerializerHelper()
            {
                _serializer = new XmlSerializer(typeof(T));
    
            }
    
            public T ToObject(string xml)
            {
                return (T)_serializer.Deserialize(new StringReader(xml));
            }
    
            public string ToString(T obj, string encoding)
            {
                using (var memoryStream = new MemoryStream())
                {
                    _serializer.Serialize(memoryStream, obj);
                    return Encoding.GetEncoding(encoding).GetString(memoryStream.ToArray());
                }
            }
    
            public byte[] ToByteArray(T obj, Encoding encoding = null)
            {
                var settings = GetSettings(encoding);
                using (var memoryStream = new MemoryStream())
                {
                    using (var writer = XmlWriter.Create(memoryStream, settings))
                    {
                        _serializer.Serialize(writer, obj);
                    }
                    return memoryStream.ToArray();
                }
            }
    
            private XmlWriterSettings GetSettings(Encoding encoding)
            {
                return new XmlWriterSettings
                {
                    Encoding = encoding ?? Encoding.GetEncoding("ISO-8859-1"),
                    Indent = true,
                    IndentChars = "\t",
                    NewLineChars = Environment.NewLine,
                    ConformanceLevel = ConformanceLevel.Document
                };
            }
        }
     }
