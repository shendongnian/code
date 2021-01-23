    public void OnMessageCallback(BrokeredMessage message) {
        var context = message.GetType().GetProperty("ReceiveContext", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(message);
        var receiver = (MessageReceiver)context.GetType().GetProperty("MessageReceiver", BindingFlags.Public | BindingFlags.Instance).GetValue(context);
        var queueName = receiver.Path;
    }
