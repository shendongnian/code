    readonly BackgroundWorker _worker = new BackgroundWorker();
    public loginform()
    {
        InitializeComponent();
        _worker.DoWork += worker_DoWork;
        _worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        _worker.RunWorkerAsync();
    }
    private static void worker_DoWork(object sender, DoWorkEventArgs e)
    {
        Thread.Sleep(1000);
        e.Result = checkconn == true ? "Connected" : "Not Connected";
    }
    private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        label.Text = e.Result as string;
        _worker.RunWorkerAsync(); // loops endlessly
    }
