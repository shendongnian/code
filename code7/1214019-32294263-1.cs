        public class BackgroundTimer : BackgroundWorker
        {
            private ManualResetEvent intervalManualReset;
            private enum ProcessStatus { Created, Running, JobCompleted, ExceptionOccured };
            private ProcessStatus processStatus = new ProcessStatus();
    
            public int Interval { get; set; }
            public BackgroundTimer()
            {
                this.processStatus = ProcessStatus.Created;
                this.WorkerSupportsCancellation = true;
                this.Interval = 1000;
            }
    
            protected override void OnRunWorkerCompleted(RunWorkerCompletedEventArgs e)
            {
                base.OnRunWorkerCompleted(e);
                if (processStatus == ProcessStatus.ExceptionOccured)
                    // Log : Process stopped;
                    processStatus = ProcessStatus.JobCompleted;
            }
            protected override void OnDoWork(DoWorkEventArgs e)
            {
                while (!this.CancellationPending)
                {
                    try
                    {
                        base.OnDoWork(e);
                        this.Sleep();
                    }
                    catch (Exception exception)
                    {
                        //Log excepption;
                        this.processStatus = ProcessStatus.ExceptionOccured;
                        this.Stop();
                    }
                }
                if (e != null)
                    e.Cancel = true;
            }
    
            public void Start()
            {
                this.processStatus = ProcessStatus.Running;
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
            public void Activate()
            {
                if (!this.IsBusy)
                    // Log : Process activated.
                    this.Start();
            }
        }
