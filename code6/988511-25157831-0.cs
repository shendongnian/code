    private readonly BackgroundWorker worker = new BackgroundWorker();
     
    // Initialization code
    worker.DoWork += worker_DoWork;
    worker.WorkerSupportsCancellation = true;
    worker.RunWorkerAsync();          // Runs your code in a background thread
    private void worker_DoWork(object sender, DoWorkEventArgs e)  
    {
        CreateFolders();
        //For each process get the equivalent processcode
        foreach (string item in Processes)
        {
            ItemValue = item;
            //Get process code for the process under the selected source
            GetActiveProcess();
       -->> if (worker.CancellationPending) break;
            ... your code... 
        }
    }
    void OnClickStopButoon(args) {
       worker.CancelAsync();
    }
