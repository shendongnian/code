     private void SyncBgWorkerOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
            {
              //some codes
              SyncBgWorker.ReportProgress(10);//to update the progress value
             //some codes
              SyncBgWorker.ReportProgress(50);//to update the progress value
             //some codes
              SyncBgWorker.ReportProgress(100);//to update the progress value
            }
    
    private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                var objProgressBar = (ProgressBar)this.GetTemplateChild("PrgBarSyncProgress");
                UpdateProgressBarDelegate updatePbDelegate = new UpdateProgressBarDelegate(objProgressBar.SetValue);
                Dispatcher.Invoke(updatePbDelegate, System.Windows.Threading.DispatcherPriority.Background, new object[] { ProgressBar.TagProperty, "Synchronizing " + e.ProgressPercentage.ToString() + "%" });
            }
