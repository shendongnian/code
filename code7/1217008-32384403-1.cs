    namespace WpfApplication1.ViewModel
    {
        public class MainViewModel : ViewModelBase
        {
            readonly BackgroundWorker _worker = new BackgroundWorker();
            private string _property;
    
            public MainViewModel()
            {
                _worker.DoWork += (sender, args) =>
                    {
                        while (true)
                        {
                            Property = DateTime.Now.Ticks.ToString();
                            Thread.Sleep(250);
                        }
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
