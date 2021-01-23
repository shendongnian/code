    public static class QueueClientExtensions
    {
        public static void OnCustomMessage(this QueueClient queueClient, Action<BrokeredMessage> callback,
            OnMessageOptions onMessageOptions)
        {
            queueClient.OnMessage(message =>
            {
                try
                {
                    // process the message
                    callback(message);
                    //complete if success
                    message.Complete();
                }
                catch (Exception ex)
                {
                    // Here you have access to the brokeredMessage so you can log what you want.
                    // message.GetBody<string>() 
                    Trace.TraceError("Exception captured: " + ex.Message);
                    //Abandon the message so that it could be re-process
                    message.Abandon();
                }
            }, onMessageOptions);
        }
    }
