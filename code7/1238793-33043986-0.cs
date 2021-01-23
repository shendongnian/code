    Thread workerThread = null;
    protected override void OnStart(string[] args)
    {
        this.workerThread = new Thread(this.DoWork);
        // Signal the thread to stop automatically when the process exits.
        this.workerThread.IsBackground = true;
        this.workerThread.Start();
    }
    protected override void OnStop()
    {
    }
    private void DoWork()
    {
        try
        {
            while (true)
            {
                // do your work here...
            }
        }
        catch (Exception ex)
        {
            // handle exception here...
        }
    }
