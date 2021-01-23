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
                       true, false, progressDetail.ProgressReporter);
        
            dispatcher.Invoke(() => ProgressCollection.Remove(progressDetail);
        });
    
    }
    
        public sealed class ProgressDetail : INotifyPropertyChanged
        {
            private double _progressPercentage;
            public ProgressDetail(string fileName)
            {
                FileName = fileName;
                ProgressReporter = new Progress<double>(OnProgressReported);
            }
            public string FileName { get; private set; }
            public IProgress<double> ProgressReporter { get; private set; }
            public double ProgressPercentage
            {
                get { return _progressPercentage; }
                private set
                {
                    if (value.Equals(_progressPercentage)) return;
                    _progressPercentage = value;
                    OnPropertyChanged();
                }
            }
            private void OnProgressReported(double progress)
            {
                ProgressPercentage = progress;
            }
            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                var temp = PropertyChanged;
                if(temp != null)
                    temp(this, new PropertyChangedEventArgs(propertyName));
            }
        }
