    public ObserveableCollection<ProgressDetail> ProgressCollection {get; private set;}
    
    public void CopyFiles(string dir)
    {
    
        var dispatcher = Application.Current.Dispatcher;
        Parallel.ForEach(Directory.GetFiles(dir).ToList(), file =>
        {
            ProgressDetail progressDetail = null;
            dispatcher.Invoke(() => 
            {
               // We make the `Progress` object on the UI thread so it can capture the  
               // SynchronizationContext during its construction.
               progressDetail = new ProgressDetail(file);
               ProgressCollection.Add(progressDetail);
            }
        
            XCopy.Copy(file, file.Replace(_destDetail.Source, _destDetail.Dest), 
                       true, false, progressDetail.PercentComplete);
        
            dispatcher.Invoke(() => ProgressCollection.Remove(progressDetail);
        });
    
    }
    
    public class ProgressDetail
    {
        public ProgressDetail(string fileName)
        {
            FileName = filename;
            PercentComplete = new Progress<double>();
        }
        public string FileName {get; private set;}
        public Progress<double> PercentComplete {get; private set;}
    }
