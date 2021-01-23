        public partial class Form1 : Form
        {
            EventWaitHandle _waitHandle ;
            System.Timers.Timer _timer; 
            public Form1()
            {
                InitializeComponent();
                _waitHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
                _timer = new System.Timers.Timer();
                _timer.Interval = 100;
                _timer.Elapsed += OnTimerElapsed;
                _timer.AutoReset = true;
                
            }
    
            private void OnTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
            {
                _waitHandle.Set();
            }
               
            void FuncAsync(IProgress<int> progress)
            {
                _timer.Start();
                int percent = 0;
                while (percent <= 100)
                {
                    if (_waitHandle.WaitOne())
                    {
                        progress.Report(percent);
                        percent++;
                    }
                }
                _timer.Stop();
                
            }
            void FuncBW(BackgroundWorker worker)
            {
                _timer.Start();
                int percent = 0;
                while (percent <= 100)
                {
                    if (_waitHandle.WaitOne())
                    {
                        worker.ReportProgress(percent);
                        percent++;
                    }
                }
                _timer.Stop();
            }
    
           
    
            void FuncThread()
            {
                _timer.Start();
                int percent = 0;
                while (percent <= 100)
                {
                    if (_waitHandle.WaitOne())
                    {
                        if (this.InvokeRequired)
                        {
                            this.Invoke((Action)delegate { label1.Text = percent.ToString(); });
                        }
                        else
                        {
                            label1.Text = percent.ToString();
                        }
                        percent++;
                    }
                }
                _timer.Stop();
            }
    
    
            ... your other code
        }
