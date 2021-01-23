     public bool IsEnabled
        {
            get {
                return _isEnabled;
            }
            set
            {
                _isEnabled = false;
                OnPropertyChanged("IsEnabled");
            }
        }
