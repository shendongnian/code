     private static void UploadToDb()
     {
         var currentSyncContext = TaskScheduler.FromCurrentSynchronizationContext();
    
         Task.Factory.StartNew(()=>
         {
             for (int i = 0; i <= maxRecords - 1; i++)
             {
                 progressReporter.ReportProgress(() => { 
              
                     progressbar.maximum=maxRecords; 
                     label.text="Uploading " + i;
                     progressbar.value=i;
                 });
             }
    
                    progressReporter.ReportProgress(() => {
                 label.Text = "Updating values in DB, please wait...";
             });
    
         // When this call is made the subsequent updates to the main form 
         // were not successful due to 'InvalidOperationException'.
         UpdateValuesInDb(currentSyncContext); 
    
         });
    }
    
    private void UpdateValuesInDb(SynchronizationContext context);
    {
    
        MoveValuesToNewDbDeleteFromSourceDb(values, context); 
        MoveValuesToNewDbDeleteFromSourceDb(values, context); 
        label.text="Moving values of type 3...";    
        MoveValuesToNewDbDeleteFromSourceDb(values, context); 
        MoveValuesToNewDbDeleteFromSourceDb(values, context); // This call is the final.
    }
    
    
    private void MoveValuesToNewDbDeleteFromSourceDb(string values, SynchronizationContext context)
    {
        var progressReporter = new ProgressReporter();
        Task.Factory.StartNew(() => {
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                // Tried using Stephen Cleary's code here but it fails with 
                        progressReporter.ReportProgress(() =>
                        {
                            progressBar.Maximum = maxRecords - 1;
                            Label.Text = "Uploading " + i;
                            progressBar.Value = i;
                        });
                // Need to update label and progress in for loop as mentioned above.
            }
        }, context);
    }
