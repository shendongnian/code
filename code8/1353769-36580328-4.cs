            public static string SerializeToString(T obj)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
    
                using (var memoryStream = new MemoryStream())
                using (var writer = XmlWriter.Create(memoryStream))
                {
                    serializer.Serialize(writer, obj);
                    return Encoding.UTF8.GetString(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
                }
            }
