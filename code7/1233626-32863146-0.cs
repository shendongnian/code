     public SummaryStatus()
     {
                InitializeComponent();
    
                backgroundWorker = new BackgroundWorker();
                backgroundWorker.DoWork += backgroundWorker_DoWork;
                backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
                backgroundWorker.RunWorkerAsync();
     }
