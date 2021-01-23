        public class BridgeClass
    {
      public static event Action<string> MessageReceived;
      public static void Broadcast(string message)
      {
          if (MessageReceived != null) MessageReceived(message);
      }
    }
