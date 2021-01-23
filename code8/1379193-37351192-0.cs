    private void runButton_Click(object sender, EventArgs e)
    {
        worker=new BackgroundWorker();
        worker.WorkerSupportsCancellation=true;
        worker.RunWorkerCompleted+=Bk_RunWorkerCompleted;
        worker.DoWork+=Bk_DoWork;
        worker.RunWorkerAsync();
    }
    private void cancelButton_Click(object sender, EventArgs e)
    {
        worker.CancelAsync();
    }
    void ReallyReallyLongOperation(BackgroundWorker worker)
    {
        ...within a loop
        if(worker.CancellationPending) 
        {
            return;
        }
    }
    private void Bk_DoWork(object sender, DoWorkEventArgs e)
    {
        ReallyReallyLongOperation(worker);
        if(worker.CancellationPending)
        {
            e.Cancel = true;
        }
    }
    private void Bk_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if(!e.Cancelled)
        {
            ...
        }
    }
