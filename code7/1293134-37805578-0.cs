    // Global.asmx
    var tempCounterManager = new TempPerformanceCounterManager();
    GlobalHost.DependencyResolver.Register(typeof (IPerformanceCounterManager), () => tempCounterManager);
    
    [....]
    
    // Helper Class
    public class TempPerformanceCounterManager : IPerformanceCounterManager
    {
        private readonly static PropertyInfo[] _counterProperties = GetCounterPropertyInfo();
        private readonly static IPerformanceCounter _noOpCounter = new NoOpPerformanceCounter();
    
        public TempPerformanceCounterManager()
        {
            foreach (var property in _counterProperties)
            {
                property.SetValue(this, new NoOpPerformanceCounter(), null);
            }
        }
    
        public void Initialize(string instanceName, CancellationToken hostShutdownToken)
        {
        }
    
        public IPerformanceCounter LoadCounter(string categoryName, string counterName, string instanceName, bool isReadOnly)
        {
            return _noOpCounter;
        }
    
        internal static PropertyInfo[] GetCounterPropertyInfo()
        {
            return typeof(TempPerformanceCounterManager)
                .GetProperties()
                .Where(p => p.PropertyType == typeof(IPerformanceCounter))
                .ToArray();
        }
        public IPerformanceCounter ConnectionsConnected { get; set; }
        public IPerformanceCounter ConnectionsReconnected { get; set; }
        public IPerformanceCounter ConnectionsDisconnected { get; set; }
        public IPerformanceCounter ConnectionsCurrentForeverFrame { get; private set; }
        public IPerformanceCounter ConnectionsCurrentLongPolling { get; private set; }
        public IPerformanceCounter ConnectionsCurrentServerSentEvents { get; private set; }
        public IPerformanceCounter ConnectionsCurrentWebSockets { get; private set; }
        public IPerformanceCounter ConnectionsCurrent { get; private set; }
        public IPerformanceCounter ConnectionMessagesReceivedTotal { get; private set; }
        public IPerformanceCounter ConnectionMessagesSentTotal { get; private set; }
        public IPerformanceCounter ConnectionMessagesReceivedPerSec { get; private set; }
        public IPerformanceCounter ConnectionMessagesSentPerSec { get; private set; }
        public IPerformanceCounter MessageBusMessagesReceivedTotal { get; private set; }
        public IPerformanceCounter MessageBusMessagesReceivedPerSec { get; private set; }
        public IPerformanceCounter ScaleoutMessageBusMessagesReceivedPerSec { get; private set; }
        public IPerformanceCounter MessageBusMessagesPublishedTotal { get; private set; }
        public IPerformanceCounter MessageBusMessagesPublishedPerSec { get; private set; }
        public IPerformanceCounter MessageBusSubscribersCurrent { get; private set; }
        public IPerformanceCounter MessageBusSubscribersTotal { get; private set; }
        public IPerformanceCounter MessageBusSubscribersPerSec { get; private set; }
        public IPerformanceCounter MessageBusAllocatedWorkers { get; private set; }
        public IPerformanceCounter MessageBusBusyWorkers { get; private set; }
        public IPerformanceCounter MessageBusTopicsCurrent { get; private set; }
        public IPerformanceCounter ErrorsAllTotal { get; private set; }
        public IPerformanceCounter ErrorsAllPerSec { get; private set; }
        public IPerformanceCounter ErrorsHubResolutionTotal { get; private set; }
        public IPerformanceCounter ErrorsHubResolutionPerSec { get; private set; }
        public IPerformanceCounter ErrorsHubInvocationTotal { get; private set; }
        public IPerformanceCounter ErrorsHubInvocationPerSec { get; private set; }
        public IPerformanceCounter ErrorsTransportTotal { get; private set; }
        public IPerformanceCounter ErrorsTransportPerSec { get; private set; }
        public IPerformanceCounter ScaleoutStreamCountTotal { get; private set; }
        public IPerformanceCounter ScaleoutStreamCountOpen { get; private set; }
        public IPerformanceCounter ScaleoutStreamCountBuffering { get; private set; }
        public IPerformanceCounter ScaleoutErrorsTotal { get; private set; }
        public IPerformanceCounter ScaleoutErrorsPerSec { get; private set; }
        public IPerformanceCounter ScaleoutSendQueueLength { get; private set; }
    }
    
    internal class NoOpPerformanceCounter : IPerformanceCounter
    {
        public string CounterName
        {
            get
            {
                return GetType().Name;
            }
        }
        public long Decrement()
        {
            return 0;
        }
        public long Increment()
        {
            return 0;
        }
        public long IncrementBy(long value)
        {
            return 0;
        }
        public long RawValue
        {
            get { return 0; }
            set { }
        }
        public void Close()
        {
        }
        public void RemoveInstance()
        {
        }
        public CounterSample NextSample()
        {
            return CounterSample.Empty;
        }
    }
