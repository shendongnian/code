    namespace StackOverflow
    {
        public class XmlSerializerHelper<T> where T : class 
        {
            private readonly XmlSerializer _serializer;
    
            public XmlSerializerHelper()
            {
                _serializer = new XmlSerializer(typeof(T));
            }
    
            public T BytesToObject(byte[] bytes)
            {
                using (var memoryStream = new MemoryStream(bytes))
                {
                    using (var reader = new XmlTextReader(memoryStream))
                    {
                        return (T)_serializer.Deserialize(reader);
                    }
                }
            }
        }
    }
