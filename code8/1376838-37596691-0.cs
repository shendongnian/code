    private static MyMessage RecieveMessage()
    {
        if (!MessageQueue.Exists(QueueName))
        {
            return null;
        }
        using (var msmq = new MessageQueue(QueueName))
        {
            msmq.Formatter = new XmlMessageFormatter(new Type[] { typeof(MyMessage) });
            var message = msmq.Receive();
            return message != null && message.Body is MyMessage ? (MyMessage)message.Body : null;
        }
    }
