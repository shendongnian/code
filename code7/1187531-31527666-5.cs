        ManualResetEvent stateChange = new ManualResetEvent(false);
        public ManualResetEvent stateChangeDone = new ManualResetEvent(false);
        private void Form2_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();  
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while(stateChange.WaitOne())
            {
                stateChange.Reset();
                var progressDone = new AutoResetEvent(false);
                int progress = 0;
                using(var timer = new System.Threading.Timer(_=>
                    { 
                        backgroundWorker1.ReportProgress(progress);
                        progress += 2;
                        if (progress>=100)
                        {
                            progressDone.Set();
                        }
                    }, null, 0, 25))
                {
                    progressDone.WaitOne();
                }
                stateChangeDone.Set();
            }
        }
