    public interface ICheckPointer
    {
        Task CheckpointAsync(PartitionContext context);
    }
    public class CheckPointer : ICheckPointer
    {
        public Task CheckPointAsync(PartitionContext context)
        {
            return context.CheckpointAsync();
        }
    }
In your unit test method you can now mock the interface and check whether CheckPointAsync is called.
Your implementation of IEventProcessor now should accept an instance of ICheckPointer:
    public class SampleEventProcessor : IEventProcessor
    {
		private ICheckPointer checkPointer;
		
		public SampleEventProcessor(ICheckPointer checkPointer)
		{
		    this.checkPointer = checkPointer;
		}
		
        public Task OpenAsync(PartitionContext context)
        {
            return Task.FromResult<object>(null);
        }
        public async Task ProcessEventsAsync(PartitionContext context, IEnumerable<EventData> events)
        {
            ...
            
            await checkPointer.CheckpointAsync(context);
        }
        public async Task CloseAsync(PartitionContext context, CloseReason reason)
        {
            return Task.FromResult<object>(null);
        }
    }
You will need an implementation of IEventProcessorFactory to inject the ICheckPoint interface:
    internal class SampleEventProcessorFactory : IEventProcessorFactory
    {
        private readonly ICheckPointer checkPointer;
        public SampleEventProcessorFactory (ICheckPointer checkPointer)
        {
            this.checkPointer = checkPointer;
        }
        public IEventProcessor CreateEventProcessor(PartitionContext context)
        {
            return new SampleEventProcessor(checkPointer);
        }
    }
