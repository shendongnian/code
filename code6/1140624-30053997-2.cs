    //with semaphore
    var semaphore = new Semaphore(0,2);
    for(long key = 0; key < 5; key++)
    {
        semaphore.WaitOne();
        ProcessWorking();
        semaphore.Release();
    }
    public void ProcessWorking()
    {
        var processingThread = new Thread(() => DoDataSetup(key));                         
        _progress = new ProgressReport(processingThread);
        _progress.Show();
        _progress.FormClosed += delegate(object delSender, FormClosedEventArgs args)
        {
            this.Enabled = true;
        };
        this.Enabled = false;
        processingThread.Start();
    }
