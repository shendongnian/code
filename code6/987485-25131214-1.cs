    // Search Form : the observable responsible for sending search data back to other forms
    public partial class SearchForm : Form, IObservable<SearchData>
    {
        private List<IObserver<SearchData>> _observers;
        public SearchForm()
        {
            _observers = new List<IObserver<SearchData>>();
            InitializeComponent();
        }
        public IDisposable Subscribe(IObserver<SearchData> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
            return new Unsubscriber(_observers, observer);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
        private void Search()
        {
            SearchData newSearch = new SearchData();
            SearchData searchValue  = newSearch.Search();
            foreach (var observer in _observers)
            {
                if (searchValue == null)
                    observer.OnError(new Exception("pass some expection"));
                else
                    observer.OnNext(searchValue);
            }
        }
    }
