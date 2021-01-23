    // First you create the message with the needed properties.
    public SomeMessage
    {
        public string Content { get; set; }
    }
    // Then at some places you register for listening to this type of message
    Messenger.Default.Register<SomeMessage>(
        this,
        message => YourMethodThatProcessesTheMessage(message)
    );
    // Your method knows the exact type of the message
    // So you can access all the properties of the message
    private void YourMethodThatProcessesTheMessage(SomeMessage message)
    {
        Console.WriteLine(message.Content);
    }
    // At another place you can simply send a message to all the listeners
    var message = new SomeMessage() { Content = "something" };
    Messenger.Default.Send<SomeMessage>(message);
