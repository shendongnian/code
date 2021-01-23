    public class SimpleEventProcessor : IEventProcessor 
    {
        public static event EventHandler<MessageReceivedEventArgs> OnMessageReceived;        
        public SimpleEventProcessor()
        { }
    }
       
