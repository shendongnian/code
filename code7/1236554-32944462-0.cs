    public static class JsonExtensions
    {
        public static void SerializeToFileCompressed(object value, string path, JsonSerializerSettings settings = null)
        {
            using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Read))
                SerializeCompressed(value, fs, settings);
        }
        public static void SerializeCompressed(object value, Stream stream, JsonSerializerSettings settings = null)
        {
            using (var compressor = new GZipStream(stream, CompressionMode.Compress))
            using (var writer = new StreamWriter(compressor))
            {
                var serializer = JsonSerializer.CreateDefault(settings);
                serializer.Serialize(writer, value);
            }
        }
        public static T DeserializeFromFileCompressed<T>(string path, JsonSerializerSettings settings = null)
        {
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                return DeserializeCompressed<T>(fs, settings);
        }
        public static T DeserializeCompressed<T>(Stream stream, JsonSerializerSettings settings = null)
        {
            using (var compressor = new GZipStream(stream, CompressionMode.Decompress))
            using (var reader = new StreamReader(compressor))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var serializer = JsonSerializer.CreateDefault(settings);
                return serializer.Deserialize<T>(jsonReader);
            }
        }
    }
