    private BackgroundWorker bgw = new BackgroundWorker();
    public MainWindow()
    {
        InitializeComponent();
        bgw.DoWork += Bgw_DoWork;
        bgw.RunWorkerCompleted += Bgw_RunWorkerCompleted;
        bgw.WorkerSupportsCancellation = true;
    }
    private void button3_Click(object sender, EventArgs e)
    {
        if (!bgw.IsBusy)
        {
            bgw.RunWorkerAsync();
            ((Button)sender).Content = "Cancel";
        }
        else
        {
            bgw.CancelAsync();
        }
    }
    private void Bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        button.Content = "Start";
    }
    
    private void Bgw_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = sender as BackgroundWorker;
        var server = new TcpListener(IPAddress.Any, 619);
        server.Start();
        while (true)
        {
            if (worker.CancellationPending)
            {
                e.Cancel = true;
                server.Stop();
                break;
            }
            else
            {
                if (server.Pending())
                {
                    var client = listener.AcceptTcpClient();
                    // handle client here or do something like below to return the client to the RunWorkerCompleted method in 
                    // e.result
                    e.Result = client;
                    break;
                }
            }
        }
    }
