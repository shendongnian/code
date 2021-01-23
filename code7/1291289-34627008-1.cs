    public class DataTableMediaTypeFormatter : BufferedMediaTypeFormatter
    {
        public DataTableMediaTypeFormatter()
            : base()
        {
            SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("test/dt"));
        }
        public override object ReadFromStream(Type type, System.IO.Stream readStream,
            System.Net.Http.HttpContent content, IFormatterLogger formatterLogger, System.Threading.CancellationToken cancellationToken)
        {
            var data = new StreamReader(readStream).ReadToEnd();
            var obj = JsonConvert.DeserializeObject<DataTable>(data);
            return obj;
        }
        public override bool CanReadType(Type type)
        {
            return true;
        }
        public override bool CanWriteType(Type type)
        {
            return true;
        }
    }
    header of my request -
    User-Agent: Fiddler
    Host: localhost:60957
    Content-Type : test/dt
    Content-Length: 28
