    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
    
            Items = new ObservableCollection<MyFirstData>()
            {
                new MyFirstData() {Id = 1, Name = "foo"},
                new MyFirstData() {Id = 2, Name = "bar"},
                new MyFirstData() {Id = 3, Name = "marble"},
            };
            ItemsView = CollectionViewSource.GetDefaultView(Items);
            
            DataContext = this;
        }
    
        private string _filterText;
    
        public string FilterText
        {
            get { return _filterText; }
            set
            {
                _filterText = value;
                ItemsView.Filter = DoFilter;
                OnPropertyChanged();
            }
        }
    
        private bool DoFilter(object obj)
        {
            var myFirstData = obj as MyFirstData;
            if (myFirstData != null)
            {
                return myFirstData.Filter(FilterText);
            }
            return false;
        }
    
        public ObservableCollection<MyFirstData> Items { get; set; }
        public ICollectionView ItemsView { get; set; }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
