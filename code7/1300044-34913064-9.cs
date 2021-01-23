    public class ProtocolsLayer 
    {
        public ProtocolsLayer(IProtocolFactory protocolFactory)
        {
            this._protocolFactory = protocolFactory; 
        }
        private readonly IProtocolFactory _protocolFactory;
        public void HandleConnection1()
        {
            IProtocol protocol = this._protocolFactory.Create("Protocol1"); 
        }
    }
