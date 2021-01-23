        public static string ToString(T obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            // This MemoryStream is disposed automatically when the writer is Disposed.
            var memoryStream = new MemoryStream();
            using (var writer = XmlWriter.Create(memoryStream))
            {
                serializer.Serialize(writer, obj);
            }
            // The memory stream buffer can be accessed even when it has been disposed.
            return Encoding.UTF8.GetString(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
        }
