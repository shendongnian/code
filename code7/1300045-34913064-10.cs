    public class ProtocolsLayer 
    {
        public ProtocolsLayer(Func<String, IProtocol> protocolFactory)
        {
            this._protocolFactory = protocolFactory; 
        }
        private readonly Func<String, IProtocol> _protocolFactory;
        public void HandleConnection1()
        {
            IProtocol protocol = this._protocolFactory("Protocol1"); 
        }
    }
