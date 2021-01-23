    using System.Collections.ObjectModel;
    using System.ComponentModel;
    
    internal static ObservableCollection<string> remoteSqlServers;
    
    public BackgroundWorker Sync = new BackgroundWorker();
    public MyControl()
    {
        InitializeComponent();
    
        remoteSqlServers = new ObservableCollection<string>();
    
        Sync.DoWork += Sync_DoWork;
        Sync.RunWorkerCompleted += Sync_RunWorkerCompleted;
        Sync.WorkerSupportsCancellation = true;
        Sync.RunWorkerAsync();
    
    }
    
    private void Sync_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = sender as BackgroundWorker;
        if ((worker.CancellationPending == true))
        {
            e.Cancel = true;
        }
        else
        {
            return SqlEnumerationHelper().SqlEnumerateRemote();
        }
    }
    
    private void Sync_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if ((e.Cancelled == false))
        {
            if (e.Result != null)
            {
                remoteSqlServers = (SqlServers)e.Result;
            }
        }
    }
