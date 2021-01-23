        private ObservableCollection<VNode> _selectedvnodes;
        public ObservableCollection<VNode> SelectedVNodes
        {
            get { return _selectedvnodes; }
            set
            {
                _selectedvnodes = value;
                NotifyPropertyChanged("SelectedVNodes");
            }
        }
        public MainViewModel()
        {
            VNodes = new ObservableCollection<VNode>();
            SelectedVNodes = new ObservableCollection<VNode>();
            // ...etc., just as you have it now.
