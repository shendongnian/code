    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<string> stuffs;
        private string searchText;
        private ICollectionView stuffFilterView;
        public ICollectionView StuffFilterView
        {
            get { return stuffFilterView; }
            set
            {
                if (Equals(value, stuffFilterView)) return;
                stuffFilterView = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<String> Stuffs
        {
            get { return stuffs; }
            set
            {
                if (Equals(value, stuffs)) return;
                stuffs = value;
                OnPropertyChanged();
            }
        }
        public String SearchText
        {
            get { return searchText; }
            set
            {
                if (value == searchText) return;
                searchText = value;
                OnPropertyChanged();
                OnSearchTextChanged();
            }
        }
        private void OnSearchTextChanged()
        {
            StuffFilterView.Refresh();
            
        }
        public MainViewModel()
        {
            // Bad pie!
            Stuffs = new ObservableCollection<string> {"jall", "b", "c", "d", "blabla"};
            StuffFilterView = CollectionViewSource.GetDefaultView(Stuffs);
            StuffFilterView.Filter = FilterStuff;
        }
        private bool FilterStuff(object obj)
        {
            String str = obj.ToString();
            if (String.IsNullOrEmpty(SearchText))
                return true;
            return str.Contains(SearchText);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator] // R# remove if you don't have it
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
