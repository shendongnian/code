    public void searchForAll(object sender, DoWorkEventArgs e)
    {
       //Define background worker
       var MyBack = (BackgroundWorker)sender;
       for(...)
       {
         //Send some data to ReportProgress
         MyBack.ReportProgress(0, "any object of any form goes here");
       }
    }
