    public static partial class DataContractJsonSerializerHelper
    {
        private static MemoryStream GenerateStreamFromString(string value)
        {
            return new MemoryStream(Encoding.Unicode.GetBytes(value ?? ""));
        }
    
        public static string SerializeJson<T>(T obj, DataContractJsonSerializer serializer = null)
        {
            serializer = serializer ?? new DataContractJsonSerializer(obj.GetType());
            using (var memory = new MemoryStream())
            {
                serializer.WriteObject(memory, obj);
                memory.Seek(0, SeekOrigin.Begin);
                using (var reader = new StreamReader(memory))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    
        public static T DeserializeJson<T>(string json, DataContractJsonSerializer serializer = null)
        {
            serializer = serializer ?? new DataContractJsonSerializer(typeof(T));
            using (var stream = GenerateStreamFromString(json))
            {
                var obj = serializer.ReadObject(stream);
                return (T)obj;
            }
        }
    }
