    public class MyDecimalFormatter : MediaTypeFormatter
    {
        public MyDecimalFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
            SupportedEncodings.Add(Encoding.UTF8);
        }
        public override bool CanReadType(Type type)
        {
            return false;
        }
        public override bool CanWriteType(Type type)
        {
            return type == typeof(decimal);
        }
        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content,
            TransportContext transportContext)
        {
            var decimalValue = (decimal)value;
            var formatted = decimalValue.ToString("F2", CultureInfo.InvariantCulture);
            using (var writer = new StreamWriter(writeStream))
            {
                writer.Write(formatted);
            }
            return Task.FromResult(0);
        }
    }
