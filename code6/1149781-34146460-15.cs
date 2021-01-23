    public interface IBrokeredMessageProcessor
    {
        Task ProcessAsync(BrokeredMessage incommingMessage, CancellationToken token);
    }
    public class BrokeredMessageProcessor : IBrokeredMessageProcessor
    {
        private readonly ISingletonDependency _singletonDependency;
        private readonly IScopedDependency _scopedDependency;
        public BrokeredMessageProcessor(ISingletonDependency singletonDependency, IScopedDependency scopedDependency)
        {
            _singletonDependency = singletonDependency;
            _scopedDependency = scopedDependency;
        }
        public async Task ProcessAsync(BrokeredMessage incommingMessage, CancellationToken token)
        {
            ...
        }
    }
