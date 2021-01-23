     public class ProgressBarEventArgs:EventArgs 
     {
            public int CompletedPercent{get;set;}
     }
    public class BackgroundThread
    {
        public static event EventHandler<ProgressBarEventArgs> CompletedEventHandler;
      
        public void backgroundWorker_ProgressChanged(object sender,ProgressChangedEventArgs e)
        {
            Overall.EverythingOk = e.ProgressPercentage.ToString();
            if (CompletedEventHandler != null)
            {
                CompletedEventHandler(sender, new ProgressBarEventArgs { CompletedPercent = e.ProgressPercentage });
            }
        }
     
    }
