    public async Task CloseAsync(PartitionContext context, CloseReason reason)
    {
        if (OnMessageReceived != null)
        {
            foreach (EventHandler<MessageReceivedEventArgs> subscriber in OnMessageReceived.GetInvocationList())
            {
                OnMessageReceived -= subscriber;
            }
        }
    }
