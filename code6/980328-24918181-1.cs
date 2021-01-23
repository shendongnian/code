    public class Level1MessageHandler
    {
        public event EventHandler<MessageEventArgs> MessageReceived;
    }
    public class Level1SocketClient
    {
        Level1MessageHandler level1Handler;
        public event EventHandler<MessageEventArgs> MessageReceived 
        {
            add 
            {
                level1Handler.MessageReceived += value;
            }
            remove 
            {
                level1Handler.MessageReceived -= value;
            }
        }
    }
