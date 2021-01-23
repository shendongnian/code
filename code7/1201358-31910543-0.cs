    public class LibraryBackgroundTimer : BackgroundWorker
    {
        private ManualResetEvent intervalManualReset;
        public int Interval { get; set; }
        
        public LibraryBackgroundTimer()
        {
            this.WorkerSupportsCancellation = true;
            this.Interval = 1000;
        }
    
        protected override void OnDoWork(DoWorkEventArgs e)
        {
            while (!this.CancellationPending)
            {
                    base.OnDoWork(e);
                    this.Sleep();
            }
        }
        public void Start()
        {
            if (this.IsBusy)
                return;
            this.intervalManualReset = new ManualResetEvent(false);
            this.RunWorkerAsync();
        }
        public void Stop()
        {
            this.CancelAsync();
            this.WakeUp();
            this.Dispose(true);
        }
        public void WakeUp()
        {
            if (this.intervalManualReset != null)
                this.intervalManualReset.Set();
        }
        private void Sleep()
        {
            if (this.intervalManualReset != null)
            {
                this.intervalManualReset.Reset();
                this.intervalManualReset.WaitOne(this.Interval);
            }
        }
    }
