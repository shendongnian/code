    class MyClient
    {
        private readonly Func<string, IMessage> _msgFactory;
    
        public MyClient(Func<string, IMessage> msgFactory)
        {
            _msgFactory = msgFactory;   
        }
    
        public void SendMessage(string text)
        {
            IMessage msg = _msgFactory(text);
            msg.Send();
        }
    }
    //Usage:
    new MyClient(() => new Message());
    //Mocking
    new MyClient(() => new MockMessage());
