    void worker_DoWork(object sender, DoWorkEventArgs e)
    {
        // Perform some work with the object you've passed in e.g.
        MyObj foo = (MyObj)e.Argument;
        foo.Name = "foobar";
        // Notify UI
        worker.ReportProgress(100, foo);
    }
    void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        // Update UI
    }
    void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        // Worker has finished
    }
