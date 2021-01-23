    interface IMessageFactory
    {
        IMessage CreateMessage(string text);   
    }
    
    class ConcreteMessageFactory : IMessageFactory
    {
        IMessage CreateMessage(string text) { return new Message(text); }
    }
    class MockMessageFactory : IMessageFactory
    {
        public IMessage CreateMessage(string text) { return new MockMessage(text); }
    }
    
    
    class MyClient
    {
        private readonly IMessageFactory _msgFactory;
    
        public MyClient(IMessageFactory msgFactory)
        {
            _msgFactory = msgFactory;   
        }
    
        public void SendMessage(string text)
        {
            IMessage msg = _msgFactory.CreateMessage(text);
            msg.Send();
        }
    }
    //Usage:
    new MyClient(new ConcreteMessageFactory());
    //Mocking
    new MyClient(new MockMessageFactory());
