            private void btnProgNum_Click(object sender, EventArgs e)
            {
            int n = int.Parse(txtNumProg.Text);
            int counter = 0;
            while (counter != n + 1)
            {
                counter++;
            }
                progBarNum.Maximum = n;
                backgroundWorker1.RunWorkerAsync();
                backgroundWorker1.WorkerReportsProgress = true;
                     
           }
      
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int i = 1;
            int n = int.Parse(txtNumProg.Text);
            while (i <= n )
            {
                System.Threading.Thread.Sleep(500);
                backgroundWorker1.ReportProgress(i);
                i++;
             }
        }
     
        private void backgroundWorker1_ProgressChanged_1(object sender, ProgressChangedEventArgs e)
        {
        progBarNum.Value = e.ProgressPercentage;
            lblOutProg.Text = DateTime.Now.ToString();
        }
