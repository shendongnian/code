    public class ReportingTimer
    {
        public event EventHandler Elapsed;
        private int _interval;
        private BackgroundWorker _worker;
        public ReportingTimer(int interval)
        {
            _interval = interval;
            _worker = new BackgroundWorker();
            _worker.WorkerReportsProgress = true;
            _worker.WorkerSupportsCancellation = true;
            _worker.DoWork += _worker_DoWork;
            _worker.ProgressChanged += _worker_ProgressChanged;
          
        }
        public void Start()
        {
            if (!_worker.IsBusy)
            {
                _worker.RunWorkerAsync();
            }
        }
        public void Stop()
        {
            if (_worker.IsBusy)
            {
                _worker.CancelAsync();
            }
        }
        private void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!_worker.CancellationPending)
            {
                Thread.Sleep(_interval);
                _worker.ReportProgress(1);
            }
            if (_worker.CancellationPending)
            {
                e.Cancel = true;
            }
        }
        private void _worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!_worker.CancellationPending)
            {
                if (Elapsed != null)
                { 
                    Elapsed(this, new EventArgs());
                } 
                
            }
        }
    }
