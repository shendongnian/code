    public class JsonTextFormatter : MediaTypeFormatter
    {
        public readonly JsonSerializerSettings JsonSerializerSettings;
        private readonly UTF8Encoding _encoding;
        public JsonTextFormatter(JsonSerializerSettings jsonSerializerSettings = null)
        {
            JsonSerializerSettings = jsonSerializerSettings ?? new JsonSerializerSettings();
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
            _encoding = new UTF8Encoding(false, true);
            SupportedEncodings.Add(_encoding);
        }
        public override bool CanReadType(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException();
            }
            return true;
        }
        public override bool CanWriteType(Type type)
        {
            return true;
        }
        public override Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
        {
            var serializer = JsonSerializer.Create(JsonSerializerSettings);
            return Task.Factory.StartNew(() =>
            {
                using (var streamReader = new StreamReader(readStream, _encoding))
                {
                    using (var jsonTextReader = new JsonTextReader(streamReader))
                    {
                        return serializer.Deserialize(jsonTextReader, type);
                    }
                }
            });
        }
        public override Task WriteToStreamAsync(Type type, Object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {
            var serializer = JsonSerializer.Create(JsonSerializerSettings);
            return Task.Factory.StartNew(() =>
            {
                using (
                    var jsonTextWriter = new JsonTextWriter(new StreamWriter(writeStream, _encoding))
                    {
                        CloseOutput = false
                    })
                {
                    serializer.Serialize(jsonTextWriter, value);
                    jsonTextWriter.Flush();
                }
            });
        }
    }
