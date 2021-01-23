    public interface ICloudQueueWrapper
    {
        Task AddMessageAsync(CloudQueueMessage message);
    }
    public class CloudQueueWrapper : ICloudQueueWrapper
    {
        private readonly CloudQueue _cloudQueue;
        public CloudQueueWrapper(CloudQueue cloudQueue)
        {
            cloudQueue.ShouldNotBeNull();
            _cloudQueue = cloudQueue;
        }
        public async Task AddMessageAsync(CloudQueueMessage message)
        {
            message.ShouldNotBeNull();
            await _cloudQueue.AddMessageAsync(message);
        }
    }
