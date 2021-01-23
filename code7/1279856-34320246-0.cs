    // Not a real NServiceBus thing! Only exists in my imagination!
    public interface IHandleMessageBatches<TMessage>
    {
        void Handle(TMessage[] messages);
        int MaxBatchSize { get; }
    }
