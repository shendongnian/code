    class MainWindowViewModel : INotifyPropertyChanged
    {
        ObservableCollection<MapVM> _items = new ObservableCollection<MapVM>();
        public ObservableCollection<MapVM> Items { get { return _items; } }
        public MainWindowViewModel()
        {
            Items.Add(new MapVM() { UpDownButtonVisibility = Visibility.Visible, Address = "1111111" });
            Items.Add(new MapVM() { UpDownButtonVisibility = Visibility.Collapsed, Address = "222222" });
            Items.Add(new MapVM() { UpDownButtonVisibility = Visibility.Visible, Address = "33333333" });
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    
    class MapVM : INotifyPropertyChanged
    {
        public MapVM()
        {
            this.UpDownButtonVisibility = Visibility.Collapsed;
            this.TargetButtonVisibility = Visibility.Collapsed;
        }
        private Visibility _upDownButtonVisibility;
        public Visibility UpDownButtonVisibility
        {
            get { return _upDownButtonVisibility; }
            set
            {
                _upDownButtonVisibility = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UpDownButtonVisibility)));
            }
        }
        private Visibility _targetButtonVisibility;
        public Visibility TargetButtonVisibility
        {
            get { return _targetButtonVisibility; }
            set
            {
                _targetButtonVisibility = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TargetButtonVisibility)));
            }
        }
        private string _address;
        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Address)));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
