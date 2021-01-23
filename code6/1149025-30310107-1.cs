    using System;
    using System.ComponentModel;
    
    namespace Timers
    {
        public class HandmadeTimer
        {
            private int interval = 100;
            private bool enabled = false;
            private BackgroundWorker BGW = new BackgroundWorker();
    
            public HandmadeTimer(int interval)
            {
                this.interval = interval;
                this.enabled = false;
                this.BGW.WorkerSupportsCancellation = true;
                this.BGW.DoWork += BGW_DoWork;
                this.BGW.WorkerReportsProgress = true;
                this.BGW.ProgressChanged += BGW_ProgressChanged;
            }
    
            public void Start()
            {
                if (!(enabled))
                {
                    enabled = true;
                    BGW.RunWorkerAsync();
                    StartedEventHandler handler = Started;
                    if (!(handler == null))
                        handler();
                }
            }
    
            public void Stop()
            {
                if (enabled)
                {
                    enabled = false;
                    BGW.CancelAsync();
                    StoppedEventHandler handler = Stopped;
                    if (!(handler == null))
                        handler();
                }
            }
    
            public bool Enabled
            {
                get { return this.enabled; }
                set { if (value)  Start(); else Stop(); }
            }
    
            public int Interval
            {
                get { return this.interval; }
                set { if (value > 0) this.interval = value; }
            }
    
            private void BGW_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
            {
                long counter = Environment.TickCount + this.interval;
                do
                {
                    if (counter <= Environment.TickCount)
                    {
                        BGW.ReportProgress(100);
                        counter += this.interval;
                    }
                } while (this.enabled);
            }
    
            private void BGW_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
            {
                ElapsedEventHandler handler = Elapsed;
                if (!(handler == null))
                    handler();
            }
    
            public delegate void ElapsedEventHandler();
            public event ElapsedEventHandler Elapsed;
            public delegate void StartedEventHandler();
            public event StartedEventHandler Started;
            public delegate void StoppedEventHandler();
            public event StoppedEventHandler Stopped;
        }
    }
