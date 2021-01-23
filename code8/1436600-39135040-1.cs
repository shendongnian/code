    public class MyHelloService : HelloService
    {
        private XmlWriterSpy _xmlSpy;
        public MyHelloService() : base() { }
        protected override XmlWriter GetWriterForMessage(SoapClientMessage message, int bufferSize)
        {
            _xmlSpy = new XmlWriterSpy(base.GetWriterForMessage(message, bufferSize));
            return _xmlSpy;
        }
        public string Xml => _xmlSpy?.Xml;
    }
