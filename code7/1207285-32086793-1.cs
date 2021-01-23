    BackgroundWorker bw = new BackgroundWorker();
    public Form1()
    {
        InitializeComponent();
        bw.WorkerReportsProgress = true;
        bw.DoWork += bw_DoWork;
        bw.ProgressChanged += bw_ProgressChanged;
    }
    void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
       label1.Text = "File Scanning --> " + e.UserState as string;     
    }
    void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        string imageloc = @"D:\Image";
        string[] files = Directory.GetFiles(imageloc);
        foreach (var item in files)
        {
           bw.ReportProgress(0, item);
           Thread.Sleep(1000);
        }
     }
    protected void button1_Click(object sender, EventArgs e)
    {
       if (!bw.IsBusy)
       {
           bw.RunWorkerAsync();
       }
    }
