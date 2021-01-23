    public class ProgressInformer {
        
        public static double Progress = 0;
        static void UploadDownloadProgress(Object sender, FileDataTransferEventArgs e)
        {
            // print a dot           
            System.Diagnostics.Debug.WriteLine(e.PercentageProgress);
            // Need to show this on a label or return to front end somehow
            //e.PercentageProgress.ToString();
            e.Cancel = false;
        }
    }
