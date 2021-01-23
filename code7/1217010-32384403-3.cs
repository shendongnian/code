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
                            // You shouldn't need this but here it is
                            // DispatcherHelper.CheckBeginInvokeOnUI(() => 
                            //    Property = DateTime.Now.Ticks.ToString()); 
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
