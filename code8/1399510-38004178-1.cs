    public static void ProcessMessageA([ServiceBusTrigger("MessageQueue")] BrokeredMessage message)
    {
        var messageType = (string) message.Properties["messageType"];
        if (messageType == "MessageA")
        {
            // Deserialize the message
            var messageA = message.GetBody<MessageA>();
            // Process the message
        }
        else if (messageType == "MessageB")
        {
            // Deserialize the message
            var messageB = message.GetBody<MessageB>();;
            // Process the message
        }
    }
