            BackgroundWorker _backgroundWorker;
        private void Init()
        {
            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.WorkerReportsProgress = true;
            _backgroundWorker.ProgressChanged += _backgroundWorker_ProgressChanged;
            _backgroundWorker.DoWork += _backgroundWorker_DoWork;
            _backgroundWorker.RunWorkerAsync();
        }
        private void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker backgroundWorker = sender as BackgroundWorker;
            Thread.Sleep(5000);
            backgroundWorker.ReportProgress(0);
            Thread.Sleep(5000);
            backgroundWorker.ReportProgress(10);
        }
        private void _backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Form form = new Form();
            form.Text = "Percentage:" + e.ProgressPercentage.ToString();
            form.Show();
        }
