        private State _deviceState;
        private ObservableCollection<object> _tabViewModelsCollection;
        public State DeviceState
        {
            get { return _deviceState; }
            set
            {
                _deviceState = value;
                RaisePropertyChanged("DeviceState");
                UpdateTabViewModelsCollection();
            }
        }
        public ObservableCollection<object> TabViewModelsCollection
        {
            get
            {
                return _tabViewModelsCollection ??
                       (_tabViewModelsCollection = new ObservableCollection<object>(GetDeviceData()));
            }
        }
        private void UpdateTabViewModelsCollection()
        {
            _tabViewModelsCollection = null;
            RaisePropertyChanged("TabViewModelsCollection");
        }
        private List<object> GetDeviceData()
        {
            //implement here the data collection process
            throw new NotImplementedException();
        }
