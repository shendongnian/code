    using System.Diagnostics;
    using System.Linq;
    
    public class NetworkMonitor
    {
        private PerformanceCounter _bytesSent;
        private PerformanceCounter _bytesReceived;
        private readonly int _processId;
        private bool _initialized;
    
        public NetworkMonitor(int processID)
        {
            _processId = processID;
            Initialize();
        }
    
        public NetworkMonitor()
            : this(Process.GetCurrentProcess().Id)
        {
    
        }
        private void Initialize()
        {
            if (_initialized)
                return;
    
            var category = new PerformanceCounterCategory(".NET CLR Networking 4.0.0.0");
            var instanceNames = category.GetInstanceNames().Where(i => i.Contains(string.Format("p{0}", _processId)));
            if (!instanceNames.Any()) return;
    
            _bytesSent = new PerformanceCounter
            {
                CategoryName = ".NET CLR Networking 4.0.0.0",
                CounterName = "Bytes Sent",
                InstanceName = instanceNames.First(),
                ReadOnly = true
            };
    
            _bytesReceived = new PerformanceCounter
            {
                CategoryName = ".NET CLR Networking 4.0.0.0",
                CounterName = "Bytes Received",
                InstanceName = instanceNames.First(),
                ReadOnly = true
            };
    
            _initialized = true;
        }
    
        public float GetSentBytes()
        {
            Initialize(); //in Net4.0 performance counter will get activated after first request
            return _initialized ? _bytesSent.RawValue : 0;
        }
        enter code here
        public float GetReceivedBytes()
        {
            Initialize(); //in Net4.0 performance counter will get activated after first request
            return _initialized ? _bytesReceived.RawValue : 0;
        }
    } 
