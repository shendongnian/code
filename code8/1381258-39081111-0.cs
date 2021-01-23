    public Message Receive(MessageQueue queue, TimeSpan timeout)
    {
        var message = queue.Receive(timeout, MessageQueueTransactionType.Automatic);
        _suppressedScope = new TransactionScope(TransactionScopeOption.Suppress, TimeSpan.Zero);
 
        return message;
    }
