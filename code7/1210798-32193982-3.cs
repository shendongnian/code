    public partial class XmlSerializerHelper
    {
        public static List<T> ReadObjects<T>(Stream stream, bool closeInput, XmlSerializer serializer)
        {
            var list = new List<T>();
            serializer = serializer ?? new XmlSerializer(typeof(T));
            var settings = new XmlReaderSettings
            {
                ConformanceLevel = ConformanceLevel.Fragment,
                CloseInput = closeInput,
            };
            using (var xmlTextReader = XmlReader.Create(stream, settings))
            {
                while (xmlTextReader.Read())
                {   // Skip whitespace
                    if (xmlTextReader.NodeType == XmlNodeType.Element)
                    {
                        using (var subReader = xmlTextReader.ReadSubtree())
                        {
                            var logEvent = (T)serializer.Deserialize(subReader);
                            list.Add(logEvent);
                        }
                    }
                }
            }
            return list;
        }    
    }
