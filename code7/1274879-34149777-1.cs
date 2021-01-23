    private BackgroundWorker bw = new BackgroundWorker();
    
            public Form()
            {
                InitializeComponent();
    
                bw.WorkerSupportsCancellation = true;
                bw.DoWork += new DoWorkEventHandler(bw_DoWork);
                bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            }
    
            private void start_Click(object sender, EventArgs e)
            {
                if (bw.IsBusy != true)
                {
                    bw.RunWorkerAsync();
                }
            }
            private void stop_Click(object sender, EventArgs e)
            {
                if (bw.WorkerSupportsCancellation)
                {
                    bw.CancelAsync();
                }
            }
            private void bw_DoWork(object sender, DoWorkEventArgs e)
            {
                BackgroundWorker worker = sender as BackgroundWorker;
    
                if ((worker.CancellationPending))
                {
                    e.Cancel = true;
                    return;
                }
    
                StartLoading(); //Some Method which performing I want to stop at any time
            }
            private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                if ((e.Cancelled == true))
                {
                    //"Canceled!";
                }
    
                else if (!(e.Error == null))
                {
                    //"Error: " + e.Error.Message);
                }
    
                else
                {
                    //"Done!";
                }
            }
