        private BackgroundWorker bgw;
        private void Form1_Load(object sender, EventArgs e)
        {
            bgw = new BackgroundWorker();
            bgw.DoWork += bgw_DoWork;
            bgw.WorkerReportsProgress = true;
            bgw.RunWorkerCompleted += bgw_RunWorkerCompleted;
            bgw.ProgressChanged += bgw_ProgressChanged;
            bgw.RunWorkerAsync();
        }
        void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
        void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox1.Image = e.Result;
        }
        private Image img;
        void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            WebClient wc = new WebClient();
            wc.DownloadProgressChanged += wc_DownloadProgressChanged;
            Stream stream = wc.OpenRead("" + textBox1.Text);
            e.Result = img;
        }
        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            bgw.ReportProgress(e.ProgressPercentage);
        }
