        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            // Perform non-GUI initialization - The GUI thread will be responsive in the meantime
            // My time consuming operation is just this loop.
            //make sure you use worker.ReportProgress() here
            for (int i = 1; (i <= 10); i++)
            {
                if ((worker.CancellationPending == true))
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    System.Threading.Thread.Sleep(500);
                    worker.ReportProgress((i * 10));
                }
            }
            SetVisible(false);
            MainForm mainForm = new MainForm();
            mainForm.ShowDialog();
            //instead of
            //this.Visible = false;
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
        }
