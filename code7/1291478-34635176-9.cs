    public static Task<Message> ReceiveAsync(this MessageQueue messageQueue)
    {
        return Task.Factory.FromAsync(messageQueue.BeginReceive(), messageQueue.EndPeek);
    }
    ...
    Message message = await messageQueue.ReceiveAsync().ConfigureAwait(false);
