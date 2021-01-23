    public interface ICloudQueueClientWrapper
    {
        ICloudQueueWrapper GetQueueReference(string queueName);
    }
    // ----------------
    public class CloudQueueClientWrapper : ICloudQueueClientWrapper
    {
        private readonly Lazy<CloudQueueClient> _cloudQueueClient;
        public CloudQueueClientWrapper(string connectionStringName)
        {
            connectionStringName.ShouldNotBeNullOrWhiteSpace();
            _cloudQueueClient = new Lazy<CloudQueueClient>(() =>
            {
                // We first need to connect to our Azure storage.
                var storageConnectionString = CloudConfigurationManager.GetSetting(connectionStringName);
                var storageAccount = CloudStorageAccount.Parse(storageConnectionString);
                // Create the queue client.
                return storageAccount.CreateCloudQueueClient();
            });
        }
        public ICloudQueueWrapper GetQueueReference(string queueName)
        {
            queueName.ShouldNotBeNullOrWhiteSpace();
            var cloudQueue = _cloudQueueClient.Value.GetQueueReference(queueName);
            return new CloudQueueWrapper(cloudQueue);
        }
        // Add more methods here which are a one-to-one match against the underlying CQC.
    }
