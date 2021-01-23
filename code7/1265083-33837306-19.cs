    public static class JsonExtensions
    {
        public static void SerializeToStream(object value, System.Web.HttpResponse response, JsonSerializerSettings settings = null)
        {
            if (response == null)
                throw new ArgumentNullException("response");
            SerializeToStream(value, response.OutputStream, settings);
        }
        public static void SerializeToStream(object value, TextWriter writer, JsonSerializerSettings settings = null)
        {
            if (writer == null)
                throw new ArgumentNullException("writer");
            var serializer = JsonSerializer.CreateDefault(settings);
            serializer.Serialize(writer, value);
        }
        public static void SerializeToStream(object value, Stream stream, JsonSerializerSettings settings = null)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");
            using (var writer = new StreamWriter(stream))
            {
                SerializeToStream(value, writer, settings);
            }
        }
    }
