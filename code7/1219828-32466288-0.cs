    public interface IPacket
    {
      string PacketType { get; }
      object Payload { get; }
    }
    
    public interface IPacketHandler
    {
      string PacketType { get; }
      void Handle(IPacket packet);
    }
    
    public class MessagePacket : IPacket, IPacketHandler
    {
      public string PacketType { get { return this.GetType().Name; } }
      public object Payload { get; private set; }
      public void Handle(IPacket packet)
      { 
        // ...
      }
    }
    
    public class PingPacket : IPacket, IPacketHandler
    {
      public string PacketType { get { return this.GetType().Name; } }
      public object Payload { get; private set; }
      public void Handle(IPacket packet)
      {
    	// ... 
      }
    }
    
    public class PacketReceiver
    {
      private readonly Dictionary<string, IPacketHandler> packetHandlerLookup;
    
      // inject handlers using favored approach...
      public PacketReceiver(IPacketHandler[] handlerReferences)
      {
        this.packetHandlerLookup = handlerReferences
    	  .ToDictionary(h => h.PacketType);
      }
    
      public void Receive(IPacket packet)
      {
        IPacketHandler handler;
        this.packetHandlerLookup.TryGetValue(packet.PacketType, out handler);
    
        if (handler == null)
    	{
    	  throw new Exception(string.Format(
    	    "Unknown packet handler for {0}",
    		packet.PacketType));
    	}
    
    	handler.Handle(packet);
      }
    }
