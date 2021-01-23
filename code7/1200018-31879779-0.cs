    public Boolean StartCommandWorker()
    {
        if (DeviceCommandWorker.Instance.IsBusy)
            return false;
        else
        {
            Console.Out.WriteLine("Called start command worker!");
            DeviceCommandWorker.Instance.RunWorkerAsync();
            return DeviceCommandWorker.Instance.IsBusy;
        }
    }
    
    public void StopCommandWorker()
    {
        Console.Out.WriteLine("Called stop command worker!");
        ProcessCommand("QUIT");
        DeviceCommandWorker.Instance.CancelAsync();
    }
    
    public Boolean ProcessCommand(String command)
    {
        DeviceCommandWorker.Instance.Commands.Add(command);
        Console.Out.WriteLine("Enqueued command \"" + command + "\" ThreadID: " + Thread.CurrentThread.ManagedThreadId);
    
        return true;
    }
    
    internal class DeviceCommandWorker : BackgroundWorker
    {
        public static DeviceCommandWorker Instance { get { return lazyInstance.Value; } }
        private static readonly Lazy<DeviceCommandWorker> lazyInstance = new Lazy<DeviceCommandWorker>(() => new DeviceCommandWorker());
    
        public BlockingCollection<String> Commands { get; set; }
    
        private DeviceCommandWorker()
        {
            WorkerSupportsCancellation = true;
            Commands = new BlockingCollection<String>();
        }
    
        protected override void OnDoWork(DoWorkEventArgs e)
        {
            Console.Out.WriteLine("Background Worker Started ThreadID: " + Thread.CurrentThread.ManagedThreadId);
    
            while (!CancellationPending)
            {
                Console.Out.WriteLine("Waiting for command on ThreadID: " + Thread.CurrentThread.ManagedThreadId);
                String aString = Commands.Take();
    
                var commandTask = Task.Factory.StartNew(() =>
                {
                    Console.Out.WriteLine("   Dequeued command \"" + aString + "\" ThreadID: " + Thread.CurrentThread.ManagedThreadId);
                    if (aString.Equals("QUIT"))
                        Console.Out.WriteLine("   Quit worker called: " + aString);
                });
            }
    
            Console.Out.WriteLine("Background Worker: Stopped!");
            e.Cancel = true;
        }
    }
