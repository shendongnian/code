    public class ProtocolsLayer 
    {
        public ProtocolsLayer(IIndex<String, Func<IProtocol>> index)
        {
            this._index = index; 
        }
        private readonly IIndex<String, Func<IProtocol>> _index;
        public void HandleConnection1()
        {
            IProtocol protocol = this._index[nameof(Protocol1)](); 
        }
    }
