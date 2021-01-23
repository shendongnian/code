    using System;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    
    namespace StackOverflow
    {
        public class XmlSerializerHelper<T> where T : class
        {
            private readonly XmlSerializer _serializer;
    
            public XmlSerializerHelper()
            {
                _serializer = new XmlSerializer(typeof(T));
            }
    
            public byte[] ObjectToByteArray(T obj, Encoding encoding = null, bool ignoreNAmespaces = false)
            {
                var settings = GetSettings(encoding);
                using (var memoryStream = new MemoryStream())
                {
                    using (var writer = XmlWriter.Create(memoryStream, settings))
                    {
                        if (ignoreNAmespaces)
                        {
                            var serializerNamespaces = new XmlSerializerNamespaces();
                            serializerNamespaces.Add("", "");
                            _serializer.Serialize(writer, obj, serializerNamespaces);
                        }
                        else
                        {
                            _serializer.Serialize(writer, obj);
                        }
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
