    public void StartConversion()
    {
        ...
        TWorkerArgument workerArgument = ...;
        worker.RunWorkerAsync(workerArgument);
        // No message box here because of asynchronous execution (please see below).
    }
    private void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
    {   
        // Get the BackgroundWorker that raised this event.
        BackgroundWorker worker = sender as BackgroundWorker;
        e.Result = Convert(worker, (TWorkerArgument)e.Argument);
    }
    private static TWorkerResult Convert(BackgroundWorker worker, TWorkerArgument workerArgument)
    {
        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }
        foreach (string file in files)
        {
            // Details...
            worker.ReportProgress(percentComplete);
        }
        return ...;
    }
    private void BackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        // Show the message box here if required.
    }
