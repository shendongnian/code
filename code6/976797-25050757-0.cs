     Form2 _f2;
        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            _f2 = new Form2();
        }
 
        private void Form1_Load(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy != true)
            {
                _f2.Show();
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                // Start the asynchronous operation.
                backgroundWorker1.RunWorkerAsync();
            }
        }
 
        private void btnStart_Click(object sender, EventArgs e)
        {
 
        }
 
        private void btnCancle_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
 
                // Cancel the asynchronous operation.
                backgroundWorker1.CancelAsync();
            }
        }
 
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
 
            for (int i = 1; i <= 100; i++)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    // Perform a time consuming operation and report progress.
                    System.Threading.Thread.Sleep(500);
 
 
                }
            }
        }
 
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
 
        }
 
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _f2.Close();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
 
        }
 
    }
