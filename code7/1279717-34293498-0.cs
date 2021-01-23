        public MainWindowViewModel()
        {
            for (int i = 0; i < 10; i++)
            {
                _vipCodes.Add(new VipCode() { Description = i.ToString() });
            }
            SelectedVipCode = _vipCodes[3];
        }
        private ObservableCollection<VipCode> _vipCodes = new ObservableCollection<VipCode>();
        
        public ObservableCollection<VipCode> VipCodes
        {
            get { return _vipCodes; }
        }
        private VipCode _selectedVipCode;
        public VipCode SelectedVipCode
        {
             get { return _selectedVipCode; }
            set
            {
                _selectedVipCode = value;
                OnPropertyChanged();
            }
        }
        protected void OnPropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
