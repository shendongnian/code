    public static class DataContractJsonSerializerHelper
    {
        private static MemoryStream GenerateStreamFromString(string value)
        {
            return new MemoryStream(Encoding.Unicode.GetBytes(value ?? ""));
        }
        public static T GetObject<T>(string json)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            using (var stream = GenerateStreamFromString(json))
            {
                return (T)serializer.ReadObject(stream);
            }
        }
    }
