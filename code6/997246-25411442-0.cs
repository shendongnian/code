    public class ErrorBodyWriter : BodyWriter
    {
        protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
        {
            if (Format == WebContentFormat.Json)
            {
                var json = JsonConvert.SerializeObject(Error);
                var jsonBytes = Encoding.UTF8.GetBytes(json);
                using (var reader = JsonReaderWriterFactory.CreateJsonReader(jsonBytes, XmlDictionaryReaderQuotas.Max)) {
                    writer.WriteNode(reader, false);
                }
            }
            else { // xml }
        }
        public ErrorBodyWriter() : base(true){}
        public ErrorMessage Error { get; set; }
        public WebContentFormat Format { get; set; }
    }
