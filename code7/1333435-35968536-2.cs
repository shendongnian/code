    public class BinaryMediaTypeFormatter : MediaTypeFormatter
    {
        private static readonly Type supportedType = typeof(byte[]);
        public BinaryMediaTypeFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/octet-stream"));
        }
        public override bool CanReadType(Type type)
        {
            return type == supportedType;
        }
        public override bool CanWriteType(Type type)
        {
            return type == supportedType;
        }
        public override async Task<object> ReadFromStreamAsync(Type type, Stream stream,
            HttpContent content, IFormatterLogger formatterLogger)
        {
            using (var memoryStream = new MemoryStream())
            {
                await stream.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
        public override Task WriteToStreamAsync(Type type, object value, Stream stream,
            HttpContent content, TransportContext transportContext)
        {
            var binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(stream, value);
            return Task.FromResult(true);
        }
    }
