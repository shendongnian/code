     private  void RefreshOldDossierFinancementCommandExecute(KeyEventArgs e)
        {
            bool processIt = false;
            
            if (e != null && e.Key == Key.Enter)
                processIt = true;
            if (e == null || processIt == true)
            {
                TaskInProgress = true;
                SBMessage = "Query in progress...";
                var uischeduler = TaskScheduler.FromCurrentSynchronizationContext();
                Task.Run(() =>
                      {
                         RefreshOldDossierFinancement(DossierFinancementEnteredKey);
                       }).ContinueWith(task => { TaskInProgress = false; },
                          CancellationToken.None,
                          TaskContinuationOptions.NotOnFaulted, uischeduler);
            }
        }
