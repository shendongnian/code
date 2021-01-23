        private static string Serialize<T>(T o)
        {
            return Serialize(o, null);
        }
        private static string Serialize<T>(T o, DataContractSerializer serializer)
        {
            string result = null;
            serializer = serializer ?? new DataContractSerializer(o.GetType());
            using (var stream = new MemoryStream())
            {
                serializer.WriteObject(stream, o);
                stream.Position = 0;
                var reader = new StreamReader(stream);
                result = reader.ReadToEnd();
            }
            return result;
        }
