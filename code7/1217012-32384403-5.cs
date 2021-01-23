    namespace WpfApplication1.ViewModel
    {
        public class MainViewModel : ViewModelBase
        {
            readonly BackgroundWorker _worker = new BackgroundWorker();
            private string _property;
    
            public MainViewModel()
            {
                _worker.WorkerReportsProgress = true;
                _worker.DoWork += (sender, args) =>
                    {
                        int iterations = 0;
                        Property = "Starting...";
                        Thread.Sleep(1000); 
                        
                        while (iterations < 5)
                        {
                            _worker.ReportProgress(iterations * 25);
                            iterations++;
                            Thread.Sleep(350);
                        }
                    };
    
                _worker.ProgressChanged += (sender, args) => 
                    Property = string.Format("Working...{0}%", args.ProgressPercentage);
                _worker.RunWorkerCompleted += (sender, args) => 
                    {
                        Property = "Done!";
                    };
    
                _worker.RunWorkerAsync();
            }
    
            public string Property
            {
                get { return _property; }
                set { _property = value; RaisePropertyChanged(); }
            }
        }
    }
