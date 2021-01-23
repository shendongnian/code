    protected void btnPause_Click(object sender, EventArgs e)
        {
            System.ComponentModel.BackgroundWorker disableWorker = new System.ComponentModel.BackgroundWorker();
            disableWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(disableWorker_DoWork);
            disableWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(disableWorker_RunWorkerCompleted);
            disableWorker.RunWorkerAsync();
        }
        void disableWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            btnPause.Enabled = true;
        }
        void disableWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            btnPause.Enabled = false;
            System.Threading.Thread.Sleep(10000);            
        }
