    private async void RefreshOldDossierFinancementCommandExecute(KeyEventArgs e)
    {
        bool processIt = false;
        if (e != null && e.Key == Key.Enter)
            processIt = true;
        if (!processIt)
            return;
        TaskInProgress = true;
        SBMessage = "Query In progress...";
        try
        {
            await Task.Run(() => RefreshOldDossierFinancement(DossierFinancementEnteredKey));
            TaskInProgress = false;
         }
         catch (Exception e)
         {
              // Do stuff
         }
    }
