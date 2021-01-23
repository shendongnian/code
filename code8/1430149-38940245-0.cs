    private void BKGWork_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = sender as BackgroundWorker;
        for (int i = 1; i <= 20; i++)
        {
           //do work
           worker.ReportProgress(i);
        }
    }
    private void BKGWork_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {  
        // This is the value of the variable i passed above
        Console.WriteLine(e.ProgressPercentage);
    }
