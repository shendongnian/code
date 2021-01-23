    public class SpecialSerializeFormatter : MediaTypeFormatter
    {
        public SpecialSerializeFormatter()
        {
            //You can add any other supported types here.
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
        }
        public override bool CanReadType(Type type)
        {
            //you can just return false if you don't want to read any differently than your default way
            //if you return true here, you should override the ReadFromStreamAsync method to do custom deserialize
            return type.IsDefined(typeof(SpecialSerializeAttribute), true));
        }
        public override bool CanWriteType(Type type)
        {
            return type.IsDefined(typeof(SpecialSerializeAttribute), true));
        }
        public override async Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content,
            TransportContext transportContext)
        {
            //value will be your object that you want to serialize
            //add any custom serialize settings here
            var json = JsonConvert.SerializeObject(value);
            //Use the right encoding for your application here
            var byteArray = Encoding.UTF8.GetBytes(json);
            await writeStream.WriteAsync(byteArray, 0, byteArray.Length);
        }
    }
