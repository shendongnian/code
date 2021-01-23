    private Thread _backgroundWorkerThread;
     
    public void StartBackgroundWorker()
    {
        BackgroundWorker backgroundWorker = new BackgroundWorker();
        backgroundWorker.DoWork += DoWork;
        backgroundWorker.RunWorkerAsync();
    }
     
    public void AbortBackgroundWorker()
    {
        if(_backgroundWorkerThread != null)
            _backgroundWorkerThread.Abort();
    }
     
    void DoWork(object sender, DoWorkEventArgs e)
    {
        try
        {
            _backgroundWorkerThread = Thread.CurrentThread;
     
            // Do your work...
        }
        catch(ThreadAbortException)
        {
            // Do your clean up here.
        }
    }
