    public class WorkerRole : RoleEntryPoint
    {
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private readonly ManualResetEvent runCompleteEvent = new ManualResetEvent(false);
        private CloudQueue _pushQueue;
        private CloudStorageAccount _storageAccount;
        public override void Run()
        {
            Trace.TraceInformation("WorkerRole1 is running");
            try
            {
                this.RunAsync(this.cancellationTokenSource.Token).Wait();
            }
            catch (Exception ex)
            {
                Trace.TraceError("[WORKER] Run error: " + ex);
            }
            finally
            {
                this.runCompleteEvent.Set();
            }
        }
        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections
            ServicePointManager.DefaultConnectionLimit = 12;
            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.
            bool result = base.OnStart();
            _storageAccount = CloudStorageAccount.Parse(RoleEnvironment.GetConfigurationSettingValue("StorageConnectionString"));
            var queueClient = _storageAccount.CreateCloudQueueClient();
            _pushQueue = queueClient.GetQueueReference("pushes");
            _pushQueue.CreateIfNotExists();
            CreatePushBroker();
            Trace.TraceInformation("Foo.PushProcess has been started");
            return result;
        }
        private void CreatePushBroker()
        {
            return;
        }
        public override void OnStop()
        {
            Trace.TraceInformation("WorkerRole1 is stopping");
            this.cancellationTokenSource.Cancel();
            this.runCompleteEvent.WaitOne();
            base.OnStop();
            Trace.TraceInformation("WorkerRole1 has stopped");
        }
        private async Task RunAsync(CancellationToken cancellationToken)
        {
            // TODO: Replace the following with your own logic.
            while (!cancellationToken.IsCancellationRequested)
            {
                Trace.TraceInformation("Working");
                CloudQueueMessage message = null;
                try
                {
                    message = _pushQueue.GetMessage();
                    if (message != null)
                    {
                        ProcessItem(message);
                    }
                }
                catch (Exception ex)
                {
                    if (message != null && message.DequeueCount > 5)
                        _pushQueue.DeleteMessage(message);
                    Trace.TraceError("[WORKER] Retrieval Failure: " + ex);
                }
                await Task.Delay(1000, cancellationToken);
            }
        }
        private void ProcessItem(CloudQueueMessage message)
        {
            return;
        }
    }
