    var messagingFactory = MessagingFactory.CreateFromConnectionString("MyConnectionString");
    var messageReceiver = messagingFactory.CreateMessageReceiver("MyQueueName");
    messageReceiver.OnMessage(message =>
    {
        // You always have access to the queue path
        var queueName = messageReceiver.Path;
    }, new OnMessageOptions());
