    public class WorkerRole : RoleEntryPoint
    {
        private static StandardKernel _kernel;
        private readonly ManualResetEvent _completedEvent = new ManualResetEvent(false);
        private BaseRepository<CallLog> _callLogRepository;
        private SubscriptionClient _client;
        private MessagingFactory _mFact;
        private NamespaceManager _nManager;
        private OnMessageOptions _options;
        public override void Run()
        {
            ManualResetEvent CompletedEvent = new ManualResetEvent(false);
            try
            {
                CallInformation callInfo;
                // Initiates the message pump and callback is invoked for each message that is received, calling close on the client will stop the pump.
                _client.OnMessage(message =>
                {
                    // Process message from subscription.
                    Trace.TraceInformation("Call Received. Ready to process message " + message.MessageId);
                    callInfo = message.GetBody<CallInformation>();
                    WriteCallData(callInfo);
                    Trace.TraceInformation("Call Processed. Clearing from topic.");
                }, _options);
            }
            catch (Exception e)
            {
                Trace.TraceInformation("Error: " + e.Message + "---" + e.StackTrace);
            }
            CompletedEvent.WaitOne();
        }
    private void writeCallData(List<CallInformation> callList)
    {
        try
        {
            Trace.TraceInformation("Calls received: " + callList.Count);
            foreach (var callInfo in callList)
            {
                Trace.TraceInformation("Unwrapping call...");
                var call = callInfo.CallLog.Unwrap();
                Trace.TraceInformation("Begin Processing: Local Call " + call.ID + " with " + callInfo.DataPoints.Length + " datapoints");
                Trace.TraceInformation("Inserting Call...");
                _callLogRepository.ExecuteSqlCommand(/*SNIP: Insert call*/);
                    Trace.TraceInformation("Call entry written. Now building datapoint list...");
                    var datapoints = callInfo.DataPoints.Select(datapoint => datapoint.Unwrap()).ToList();
                    Trace.TraceInformation("datapoint list constructed. Processing datapoints...");
                    foreach (var data in datapoints)
                    {
                        /*SNIP: Long running code. Insert our datapoints one at a time. Sometimes our messages die in the middle of this foreach. */
                    }
                    Trace.TraceInformation("All datapoints written for call with dependable ID " + call.Call_ID);
                Trace.TraceInformation("Call Processed successfully.");
            }
        }
        catch (Exception e)
        {
            Trace.TraceInformation("Call Processing Failed. " + e.Message);
        }
    }
    public override bool OnStart()
    {
        try
        {
            var connectionString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");
            _nManager = NamespaceManager.CreateFromConnectionString(connectionString);
            _nManager.Settings.OperationTimeout = new TimeSpan(0,0,10,0);
            var topic = new TopicDescription("MyTopic")
            {
                DuplicateDetectionHistoryTimeWindow = new TimeSpan(0, 0, 10, 0),
                DefaultMessageTimeToLive = new TimeSpan(0, 0, 10, 0),
                RequiresDuplicateDetection = true,
            };
            if (!_nManager.TopicExists("MyTopic"))
            {
                _nManager.CreateTopic(topic);
            }
            if (!_nManager.SubscriptionExists("MyTopic", "AllMessages"))
            {
                _nManager.CreateSubscription("MyTopic", "AllMessages");
            }
            _client = SubscriptionClient.CreateFromConnectionString(connectionString, "MyTopic", "AllMessages",
                ReceiveMode.ReceiveAndDelete);
            _options = new OnMessageOptions
            {
                    AutoRenewTimeout = TimeSpan.FromMinutes(5),
            };
            _options.ExceptionReceived += LogErrors;
            CreateKernel();
            _callLogRepository.ExecuteSqlCommand(/*SNIP: Background processing*/);
        }
        catch (Exception e)
        {
            Trace.TraceInformation("Error on roleStart:" + e.Message + "---" + e.StackTrace);
        }
        return base.OnStart();
    }
    public override void OnStop()
    {
        // Close the connection to Service Bus Queue
        _client.Close();
        _completedEvent.Set();
    }
    void LogErrors(object sender, ExceptionReceivedEventArgs e)
    {
        if (e.Exception != null)
        {
            Trace.TraceInformation("Error: " + e.Exception.Message + "---" + e.Exception.StackTrace);
            _client.Close();
        }
    }
    public IKernel CreateKernel()
    {
        _kernel = new StandardKernel();
        /*SNIP: Bind NInjectable repositories */
        return _kernel;
    }
