    ManualResetEvent _stopMonitoring = new ManualResetEvent(false);
    ManualResetEvent _monitoringStopped = new ManualResetEvent(false);
    ManualResetEvent _stopRunning = new ManualResetEvent(false);
    public void Stop()
    {
        _stopMonitoring.Set();
        _monitoringStopped.Wait();
    }
    void ExecuteMonitoring()
    {
        while (!_stopRunning.Wait(0))
        {
            Console.WriteLine("ExecuteMonitoring()");
            if(!_stopMonitoring.Wait(0))
            {
                _monitoringStopped.Unset();
                // ...
            }
            _monitoringStopped.Set();
            Thread.Sleep(1000);
        }
    }
