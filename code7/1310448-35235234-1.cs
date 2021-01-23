    public Task ProcessEventsAsync(PartitionContext context, IEnumerable<EventData> messages)
    {
        foreach (EventData message in messages)
        {
            OnMessageReceived(this, new MessageReceivedEventArgs() { ReceivedOn = DateTimeOffset.UtcNow, Message = message });
        }
    }
 
