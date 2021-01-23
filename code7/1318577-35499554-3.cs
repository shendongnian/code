    public void ButtonClick()
    {
       // Disable the button       
       myButton.Enabled = false;
       var worker = new BackgroundWorker();
       worker.ReportsProgress = true;
       worker.ProgressChanged += ProgressLog;
       worker.DoWork += TestComm;
       // Re-enable the button when the worker has completed (or failed)
       worker.RunWorkerCompleted += (o,e) => myButton.Enabled = true;
       worker.RunWorkerAsync();
    }
