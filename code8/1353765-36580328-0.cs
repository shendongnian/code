        public static string SerializeToString(T obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (var stream = new MemoryStream())
            {
                var writer = XmlWriter.Create(stream);
                serializer.Serialize(writer, obj);
                writer.Flush();
                return Encoding.UTF8.GetString(stream.GetBuffer(), 0, (int)stream.Length);
            }
        }
