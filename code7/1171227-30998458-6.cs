    public MainWindow()
    {            
        bw = new BackgroundWorker();
        bw.WorkerReportsProgress = true;
        // this....
        bw.ProgressChanged += OnProgressChanged; 
    }
