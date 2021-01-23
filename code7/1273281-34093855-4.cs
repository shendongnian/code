      private readonly BackgroundWorker backgroundWorker1 = new BackgroundWorker();
      private readonly ManualResetEvent ew = new ManualResetEvent(true);
    
      public Form1()
      {
        InitializeComponent();
        
        // this can all be done in designer too
        backgroundWorker1.WorkerReportsProgress = true;
        backgroundWorker1.DoWork += backgroundWorker1_DoWork;
        backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
        backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
        progressBar1.Minimum = 0;
        progressBar1.Maximum = 10000;
        progressBar1.Value = 0;
      }
      private void button1_Click(object sender, EventArgs e)
      {
        button1.Enabled = false;
        ew.Set();
        backgroundWorker1.RunWorkerAsync();
      }
      
      private void form2_ButtonClicked(object sender, EventArgs e)
      {
        ew.Set();
      }
      private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
      {
        for (int i = 0; i < 10000; i++)
        {
          if (i == 5000) ew.Reset();
          backgroundWorker1.ReportProgress(i);
          ew.WaitOne();
        }
      }
      private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
      {
        progressBar1.Value = e.ProgressPercentage;
        if (e.ProgressPercentage != 5000) return;
        Form2 form2 = new Form2();
        form2.ButtonClicked += form2_ButtonClicked;
        form2.Show();
      }
      private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
        button1.Enabled = true;
      }
    }
