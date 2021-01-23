    public static async void SerializeToFileCompressedAsync(object value, StorageFile file, JsonSerializerSettings settings = null)
    {
        using (var stream = await file.OpenStreamForWriteAsync())
            SerializeCompressed(value, stream, settings);
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
    public static async Task<T> DeserializeFromFileCompressedAsync<T>(StorageFile file, JsonSerializerSettings settings = null)
    {
        using (var stream = await file.OpenStreamForReadAsync())
            return DeserializeCompressed<T>(stream, settings);
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
