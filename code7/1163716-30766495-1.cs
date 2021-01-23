     private void BgWorkerOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            int min = 0;
            int oldProgress = 0;
            foreach (var hw in hwList)
            {
                // new ManualResetEvent(false).WaitOne(1);
                // Thread.Sleep(1);
                int progress = Convert.ToInt32((Double)min / hwList.Count * 100);
                min++;
                // Only report progress when it changes
                if(progress != oldProgress){
                     bgWorker.ReportProgress(progress);
                     oldProgress = progress;
                }
            }
        }
    
        // Updating the progress
        private void BgWorkerOnProgressChanged(object sender, ProgressChangedEventArgs progressChangedEventArgs)
        {
            ProgressBar.Value = progressChangedEventArgs.ProgressPercentage;
        }
