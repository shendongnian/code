        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            
            var base = 100;
            var counter = ExcelRows.Count;
            var progressCounter = 0;
            for (int i = 1; i <= ExcelRows.Count; i++)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    // Perform a time consuming operation and report progress.
                    //perform you action
                    MyRow.Save();
                    //report to the Progressbar
                    if(i % counter == 0)
                         worker.ReportProgress(progressCounter++);
                }
            }
        }
        // This event handler updates the progress. 
        private void backgroundWorker1_ProgressChanged(object sender,           ProgressChangedEventArgs e)
        {
            MyProgress.Value = string.Format("{0}/100 %",e.ProgressPercentage);
        }
