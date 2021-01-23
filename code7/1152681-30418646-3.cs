        public static object DeserializeFromStream(byte [] allBytes)
        {
            using (var stream = new MemoryStream(allBytes))
                return DeserializeFromStream(stream);
        }
        public static object DeserializeFromStream(MemoryStream stream)
        {
            IFormatter formatter = new BinaryFormatter();
            stream.Seek(0, SeekOrigin.Begin);
            object objectType = formatter.Deserialize(stream);
            return objectType;
        }
