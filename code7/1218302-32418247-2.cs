    public class AutoMessage : IDisposable
    {
        private const NetDeliveryMethod method = NetDeliveryMethod.UnreliableSequenced;
        public NetPeer Peer { get; private set; }
        public List<NetConnection> Recipients { get; private set; } 
        public NetOutgoingMessage Message { get; private set; }
        public AutoMessage(NetPeer peer, List<NetConnection> recipients)
        {
            Peer = peer;
            Recipients = recipients;
            Message = peer.CreateMessage();
        }
        public void Dispose()
        {
            Peer.SendMessage(Message, Recipients, method, 0);
        }
    }
