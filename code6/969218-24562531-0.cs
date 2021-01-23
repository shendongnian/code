    public object CurrentViewModel {
        get { return _currentViewModel; }
        set {
            _currentViewModel = value;
            OnPropertyChanged("CurrentViewModel"); //Ensure you have this or are binding to a DependencyProperty
        }
    }
