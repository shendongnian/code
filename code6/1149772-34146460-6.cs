    /// <summary>
    /// Provides methods to process <see cref="BrokeredMessage"/>.
    /// </summary>
    public interface IBrokeredMessageProcessor
    {
        Task ProcessAsync(BrokeredMessage incommingMessage);
    }
    /// <summary>
    /// Process <see cref="BrokeredMessage"/> through a triggered webjob.
    /// </summary>
    public class BrokeredMessageProcessor : IBrokeredMessageProcessor
    {
        private readonly ISingletonDependency _singletonDependency;
        private readonly IScopedDependency _scopedDependency;
        /// <summary>
        /// Initialize a new instance of the <see cref="BrokeredMessageProcessor"/> class.
        /// </summary>
        /// <param name="singletonDependency">A singleton dependency.</param>
        /// <param name="scopedDependency">A per call dependency.</param>
        public BrokeredMessageProcessor(ISingletonDependency singletonDependency, IScopedDependency scopedDependency)
        {
            _singletonDependency = singletonDependency;
            _scopedDependency = scopedDependency;
        }
        /// <summary>
        /// This function will get triggered/executed when a new message is written on an Azure Queue called queue.
        /// </summary>
        /// <param name="incommingMessage">The new message.</param>
        public async Task ProcessAsync([ServiceBusTrigger("queueName")] BrokeredMessage incommingMessage)
        {
            // Process the message.
            Console.Out.WriteLine("Singleton dependency: {0}", _singletonDependency.Dependency);
            Console.Out.WriteLine("Should be the same value at any time...");
            Console.Out.WriteLine("Scoped dependency: {0}", _scopedDependency.Dependency);
            Console.Out.WriteLine("Should be a new value per call...");
        }
