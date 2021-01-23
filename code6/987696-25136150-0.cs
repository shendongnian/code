                   private BackgroundWorker bw;
                    private void Form1_Load(object sender, EventArgs e)
                    {
                      bw = new BackgroundWorker();
                     bw.WorkerReportsProgress = true;
                     bw.DoWork += BwOnDoWork;
                     bw.WorkerSupportsCancellation = true;
                     bw.RunWorkerAsync();
                    }
                   private void BwOnDoWork(object sender, DoWorkEventArgs e)
                   {
                     GetExelData();
                     bw.CancelAsync();
                     if (this.InvokeRequired)
                            {
                                this.Invoke(new EventHandler(delegate { this.Close(); }));
                            }
                   }
