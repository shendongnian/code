    public static class DataContractJsonSerializerHelper
    {
        public static T GetObject<T>(string json, DataContractJsonSerializer serializer = null)
        {
            using (var stream = GenerateStreamFromString(json))
            {
                var obj = (serializer ?? new DataContractJsonSerializer(typeof(T))).ReadObject(stream);
                return (T)obj;
            }
        }
        public static T GetObject<T>(string json, DataContractJsonSerializerSettings settings)
        {
            return GetObject<T>(json, new DataContractJsonSerializer(typeof(T), settings));
        }
        private static MemoryStream GenerateStreamFromString(string value)
        {
            return new MemoryStream(Encoding.Unicode.GetBytes(value ?? ""));
        }
    }
