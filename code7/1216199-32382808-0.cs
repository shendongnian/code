    public class DeviceMonitorSignaling
    {
        readonly object _lockObj = new object();
    
        EventWaitHandle searchingHandle;
        EventWaitHandle monitoringHandle;
    
        bool _running;
        bool _monitoring;
        volatile Device device;
    
        MonitoringMode _monitoringMode;
    
        Thread _monitoringThread;
        Thread _searchDeviceThread;
        RulyCanceler CancelToken;
    
        // CONSTRUTOR
        public DeviceMonitorSignaling()
        {
            CancelToken = new RulyCanceler();
    
            searchingHandle = new AutoResetEvent(false);
            monitoringHandle = new AutoResetEvent(false);
    
            _monitoringThread = new Thread
                (() =>
                {
                    try { MonitorDeviceConnection(CancelToken); }
                    catch (OperationCanceledException)
                    {
                        Console.WriteLine("Canceled Search!");
                    }
                });
    
            _searchDeviceThread = new Thread(() =>
            {
                try { SearchDevices(CancelToken); }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Canceled Monitor!");
                }
            });
    
            _monitoringThread.IsBackground = true;
        }
    
    
        public void Start()
        {
            _monitoring = true;
            _running = true;
    
            _searchDeviceThread.Start();
            _monitoringThread.Start();
        }
    
        public void Stop()
        {
            CancelToken.Cancel();
    
            // One of the thread would be sleeping to identify and recall it.
            WakeSleepingThread();
        }
    
        /// <summary>
        /// Method to search the device.
        /// </summary>
        /// <param name="cancelToken"></param>
        void SearchDevices(RulyCanceler cancelToken)
        {
            while (_running)
            {
                cancelToken.ThrowIfCancellationRequested();
                Console.WriteLine("Searching devices....");
                Thread.Sleep(1000);
                device = new Device(); // may be some logic to detect the device.
    
                Console.WriteLine("Finished!!! Searching devices. Start monitoring.");
    
                if(device != null)
                {
                    // Block the search thread and start the monitoring thread.
                    ToggleMonitoringMode(); 
                }
            }
        }
    
        /// <summary>
        /// Once the device is detected 
        /// </summary>
        /// <param name="cancelToken"></param>
        void MonitorDeviceConnection(RulyCanceler cancelToken)
        {
            monitoringHandle.WaitOne();
            Console.WriteLine("monitoring started.");
    
            while (_monitoring)
            {
                cancelToken.ThrowIfCancellationRequested();
                Thread.Sleep(1000);
    
                if (device == null)
                {
                    Console.WriteLine("Disconnected Invoking search.");
                    // Block monitoring thread and awake the device search.
                    ToggleMonitoringMode();
                }
                else
                {
                    bool responding = device.isConnected;
                    Console.WriteLine("responding {0}", responding);
                    if (!responding)
                    {
                        Console.WriteLine("Not responding. Invoking search.");
                        device = null;
                        // Block monitoring thread and awake the device search.
                        ToggleMonitoringMode();
                    }
                }
            }
        }
    
    
        internal void ToggleMonitoringMode()
        {
            if (_monitoringMode == MonitoringMode.SearchDevices)
            {
                _monitoringMode = MonitoringMode.MonitorDeviceConnection;
                monitoringHandle.Set();
                searchingHandle.WaitOne();
            }
            else if (_monitoringMode == MonitoringMode.MonitorDeviceConnection)
            {
                _monitoringMode = MonitoringMode.SearchDevices;
                searchingHandle.Set();
                monitoringHandle.WaitOne();
            }
        }
    
        internal void WakeSleepingThread()
        {
            if(_monitoringMode == MonitoringMode.MonitorDeviceConnection)
            {
                searchingHandle.Set();
            }
            else
            {
                monitoringHandle.Set();
            }
        }
    
        enum MonitoringMode
        {
            SearchDevices,
            MonitorDeviceConnection
        }
    
        /// <summary>
        /// For test purpose remove the device.
        /// </summary>
        internal void DisconnectDevice()
        {
            if(device != null)
            {
                device = null;
            }
        }
    
        /// <summary>
        /// For test purpose change the device status
        /// </summary>
        internal void ChangeDeviceState()
        {
            if (device != null)
            {
                device.Disconnect();
            }
        }
    
        /// <summary>
        /// Dummy device
        /// </summary>
        internal class Device
        {
            public bool isConnected = false;
    
            public Device()
            {
                isConnected = true;
            }
    
            public void Disconnect()
            {
                isConnected = false;
            }
        }
    
        internal class RulyCanceler
        {
            object _cancelLocker = new object();
            bool _cancelRequest;
            public bool IsCancellationRequested
            {
                get { lock (_cancelLocker) return _cancelRequest; }
            }
            public void Cancel() { lock (_cancelLocker) _cancelRequest = true; }
            public void ThrowIfCancellationRequested()
            {
                if (IsCancellationRequested) throw new OperationCanceledException();
            }
        }
    }
