    using System.Threading;
    private ManualResetEvent _shutdownEvent = new ManualResetEvent(false);
    private Thread _thread;
    protected override void OnStart(string[] args)
    {
        _thread = new Thread(WorkerThreadFunc);
        _thread.Name = "My Worker Thread";
        _thread.IsBackground = false;
        _thread.Start();
    }
    protected override void OnStop()
    {
        this.Schedular.Dispose();
        this._shutdownEvent.Set();
        this._thread.Join(3000);
    }
    private void WorkerThreadFunc()
    {
        this.CheckServices();
        this.ScheduleService();
        // This while loop will continue to run, keeping the thread alive,
        // until the OnStop() method is called.
        while (!_shutdownEvent.WaitOne(0))
        {
            Thread.Sleep(1000);
        }
    }
