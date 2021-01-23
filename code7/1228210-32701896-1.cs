    public ObserveableCollection<Progress<ProgressDetail>> ProgressCollection {get; private set;}
    
    public void CopyFiles(string dir)
    {
    
        var dispatcher = Application.Current.Dispatcher;
        Parallel.ForEach(Directory.GetFiles(dir).ToList(), file =>
        {
            Progress<ProgressDetail> progress = dispatcher.Invoke(() => 
            {
               //We make the `Progress` object on the UI thread so it can capture the  
               // SynchronizationContext during its construction.
               var tmp = new Progress<ProgressDetail>();
               ProgressCollection.Add(tmp);
               return tmp;
            }
        
            PerformCopyOperation(file, progress);
        
            dispatcher.Invoke(() => ProgressCollection.Remove(progress);
        });
    
    }
    
    private static void PerformCopyOperation(string file, IProgress<ProgressDetail> progress)
    {
        while(/*...*/)
        {
            var detail = new ProgressDetail();
            detail.FileName = file;
    
            /* Do whatever here to actaully copy the file */
            /* For examples of how to do it see: http://stackoverflow.com/questions/187768/can-i-show-file-copy-progress-using-fileinfo-copyto-in-net */
    
            progress.Report(detail);
        }
    }
    
    public class ProgressDetail
    {
        public string FileName {get; set;}
        public double PercentComplete {get; set;}
    }
