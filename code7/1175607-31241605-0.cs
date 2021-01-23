    namespace EventHubTestConsole
    {
      internal class Program
      {
        private static void Main(string[] args)
        {
           const string eventHubConnectionString =
            "Endpoint=<EH endpoint>;SharedAccessKeyName=<key name>;SharedAccessKey=<key>";
           const string eventHubName = "<event hub name>";
           const string storageAccountName = "<storage account name>";
           const string storageAccountKey = "<valid storage key>";
           var storageConnectionString = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}",
            storageAccountName, storageAccountKey);
           Console.WriteLine("Connecting to storage account with ConnectionString: {0}", storageConnectionString);
           var eventProcessorHostName = Guid.NewGuid().ToString();
           var eventProcessorHost = new EventProcessorHost(
             eventProcessorHostName,
             eventHubName,
             EventHubConsumerGroup.DefaultGroupName,
             eventHubConnectionString,
             storageConnectionString);
           var epo = new EventProcessorOptions
             {
               MaxBatchSize = 100,
               PrefetchCount = 10,
               ReceiveTimeOut = TimeSpan.FromSeconds(20),
               InitialOffsetProvider = (name) => DateTime.Now.AddDays(-7)
             };
           epo.ExceptionReceived += OnExceptionReceived;
           eventProcessorHost.RegisterEventProcessorAsync<SimpleEventProcessor>(epo).Wait();
           Console.WriteLine("Receiving.  Please enter to stop worker.");
           Console.ReadLine();
           eventProcessorHost.UnregisterEventProcessorAsync().Wait();
        }
        public static void OnExceptionReceived(object sender,     ExceptionReceivedEventArgs args)
        {
          Console.WriteLine("Event Hub exception received: {0}", args.Exception.Message);
        }
      }
    }
