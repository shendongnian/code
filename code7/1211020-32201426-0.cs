    interface IPacketItem
    {
        byte[] ToArray();
    }
    
    class Packet<THeader, TContent>
        where THeader : IPacketItem
        where TContent : IPacketItem
    {
        // header and content must be initialized somehow;
        // maybe, using existing instances, maybe using new() constraint
        public THeader Header { get; private set; }
        public TContent Content { get; private set; }
        public byte[] ToArray()
        {
            // builds an array using IPacketItem.ToArray
        }
    }
    var loginPacket = new Packet<PacketHeader, LoginInfo>();
    loginPacket.Content.UserName = "user";
