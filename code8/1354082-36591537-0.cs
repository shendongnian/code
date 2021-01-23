    internal static void RunWorker()
    {
        int speed = 100;
        BackgroundWorker clickThread = new BackgroundWorker
        {
            WorkerReportsProgress = true
        };
        clickThread.DoWork += ClickThreadOnDoWork;
        clickThread.ProgressChanged += ClickThreadOnProgressChanged;
        clickThread.RunWorkerAsync(speed);
    }
    private static void ClickThreadOnProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        someLabel.Text = (string) e.UserState;
    }
    private static void ClickThreadOnDoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = (BackgroundWorker)sender;
        int speed = (int) e.Argument;
        while (!worker.CancellationPending)
        {
            Thread.Sleep(speed);
            Mouse.DoMouseClick();
            Counter++;
            worker.ReportProgress(0, "newText-Parameter");
        }
    }
}
