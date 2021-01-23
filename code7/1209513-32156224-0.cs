    // Your code
    public void Publish<TMessage>(IMessage message) 
    {
         var t = typeof(TMessage);
         MyFunction((t)message); // how can a cast message to type of TMessage?
    }
    // Modified version
    public void Publish<TMessage>(TMessage message) where TMessage : IMessage
    {
         MyFunction(message);
    }
