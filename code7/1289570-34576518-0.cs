     private ObservableCollection<string> _testListsName;
        public ObservableCollection<string> TestListsNames
        {
            get { return _testListsName; }
            set
            {
                if (_testListsName != value)
                {
                    _testListsName = value;
                    NotifyPropertyChanged("TestListsNames");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
