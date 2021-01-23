    private BackgroundWorker _backgroundWorker;
    public Form1()
    {
        InitializeComponent();
        _backgroundWorker = new BackgroundWorker();
        _backgroundWorker.WorkerReportsProgress = true;
        _backgroundWorker.WorkerSupportsCancellation = true;
        // This is the background thread
        _backgroundWorker.DoWork += BackgroundWorkerOnDoWork;
            
        // Called when you report progress
        _backgroundWorker.ProgressChanged += BackgroundWorkerOnProgressChanged;
        // Called when the worker is done
        _backgroundWorker.RunWorkerCompleted += BackgroundWorkerOnRunWorkerCompleted;
    }
    private void BackgroundWorkerOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
    {
        if (runWorkerCompletedEventArgs.Result != null)
        {
            // Handle error or throw it
            throw runWorkerCompletedEventArgs.Result as Exception;
        }
        textBox1.Text = "Worker completed";
    }
    private void BackgroundWorkerOnProgressChanged(object sender, ProgressChangedEventArgs progressChangedEventArgs)
    {
        textBox1.Text = progressChangedEventArgs.UserState as string;
    }
    private void BackgroundWorkerOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
    {
        try
        {
            for (int i = 0; i < 100 && !_backgroundWorker.CancellationPending; i++)
            {
                _backgroundWorker.ReportProgress(0, i + " cycles");
                Thread.Sleep(100);
            }
        }
        catch (Exception ex)
        {
            doWorkEventArgs.Result = ex;
        }
            
    }
    private void startButton_Click(object sender, EventArgs e)
    {
        if (!_backgroundWorker.IsBusy)
            _backgroundWorker.RunWorkerAsync();
    }
    private void cancelButton_Click(object sender, EventArgs e)
    {
        if(_backgroundWorker.IsBusy)
            _backgroundWorker.CancelAsync();
    }
