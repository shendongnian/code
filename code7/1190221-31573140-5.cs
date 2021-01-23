    public  class   SomeMessageType
    {
        public  int     SomeId;
        public  string  SomeDescription;
    }
    
    public  class   SomePublisher
    {
        public  void    DoSomethingCool(string description)
        {
            var randomizer  = new Random();
            ...
            PubSub<SomeMessageType>.Broadcast(new SomeMessageType(){SomeId = randomizer.Next(), SomeDescription = description});
        }
    }
    
    public  class   SomeListener
    {
        static                  SomeListener()
        {
            PubSub<SomeMessageType>.Listen(SomeMessageEvent);
        }
    
        private static  void    SomeMessageEvent(SomeMessageType message)
        {
            // do something with the message
        }
    }
