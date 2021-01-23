    internal class Scanner
    {
        public IObservable<EventArgs> ScanEvent
        {
            get
            {
                return Observable.FromEventPattern<EventHandler, EventArgs>(
                h => m_pCoreScanner.BarcodeEvent += h, h => m_pCoreScanner.BarcodeEvent -= h)
                .Select(x => x.EventArgs);
            }
        }
    }
    
    class ViewModel : IDisposable
    {
        private Scanner scanner;
        private IDisposable _disposable;
    
        public ViewModel()
        {
            scanner = new Scanner();
            MyList = new ObservableCollection<string>();
    
            _disposable = scanner.ScanEvent
                .ObserveOn(DispatcherScheduler.Current)
                .Subscribe(x =>
                {
                    string strBarcode = scanner.strBarcode;
                    MyList.Insert(0, strBarcode);
                });
        }
    
        public  void Dispose()
        {
            _disposable.Dispose();
        }
    
        public ObservableCollection<string> MyList { get; set; }
    } 
