    /// <summary>
    /// OnStart(): Put startup code here
    ///  - Start threads, get inital data, etc.
    /// </summary>
    /// <param name="args"></param>
    protected override void OnStart(string[] args)
    {
        Library.WriteErrorLog("--------------Service Started--------------");
        Thread MyThread = new Thread(new ThreadStart(ServiceMonitor));
        MyThread.Name = "Worker Thread";
        MyThread.IsBackground = true;
        MyThread.Start();
    }
