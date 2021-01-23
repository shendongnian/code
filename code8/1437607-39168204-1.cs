    public class ListViewWithGridViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<string> _myObservableCollection;
        public ListViewWithGridViewModel()
        {
            MyObservableCollection = new ObservableCollection<string>(new List<string> { "abc", "xyz", "pqr", "aaa", "abc", "xyz", "pqr", "aaa", "abc", "xyz", "pqr", "aaa" });
        }
        public ObservableCollection<string> MyObservableCollection
        {
            get { return _myObservableCollection; }
            set
            {
                _myObservableCollection = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
