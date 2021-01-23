    class Message {
      public abstract void Dispatch(MessageHandler handler); 
    }
    
    class PacketMessage: Message {
      override void Dispatch(MessageHandler handler) {
        handler.HandlePacket(this);
      }
    }
    
    class PingMessage: Message {
       override void Dispatch(MessageHandler handler) {
         handler.HandlePing(this);
       }
    }
    
    
    class MessageHandler {
      void HandleMessage(Message message) {
        message.Dispatch(this);   
      }
      
      void HandlePacket(PacketMessage packet) {
        ...
      }
    
      void HandlePing(PingMessage ping) {
        ...
      }
    }
