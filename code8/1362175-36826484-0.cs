    public class docUpload
    {
        static public void Doc_Upload()
        {
            dropBoxStorage.UploadFile(stream, filename, entry, ProgressInformer.UploadDownloadProgress);
        } 
    }
    public class ProgressInformer {
        
        public static string Progress = "0";
        static void UploadDownloadProgress(Object sender, FileDataTransferEventArgs e)
        {
            // print a dot           
            System.Diagnostics.Debug.WriteLine(e.PercentageProgress);
            // Need to show this on a label or return to front end somehow
            ProgressInformer.Progress = e.PercentageProgress.ToString();
            e.Cancel = false;
        }
    }
