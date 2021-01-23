     public class BackgroundThread : BackgroundWorker
        {
            public BackgroundThread()
            {
                this.WorkerSupportsCancellation = true;
            }
            protected override void OnDoWork(DoWorkEventArgs e)
            {
                try
                {
                    base.OnDoWork(e);
                }
                catch (Exception exception)
                {
                    //Log Exception
                }
            }
            public void Run()
            {
                if (this.IsBusy)
                    return;
                this.RunWorkerAsync();
            }
            public void Stop()
            {
                this.CancelAsync();
                this.Dispose(true);
            }
        }
