    public class ProtocolFactory : IProtocolFactory
    {
        public ProtocolFactory(IIndex<String, IProtocol> index)
        {
            this._index = index; 
        }
        private readonly IIndex<String, IProtocol> _index; 
    
        public IProtocol Create(String protocolName)
        {
            return this._index[typeof(TProtocol).Name]; 
        }
    }    
