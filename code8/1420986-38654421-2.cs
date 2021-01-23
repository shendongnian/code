    private ViewModelBase _myCurrentView;
    public ViewModelBase MyCurrentView
    {
        get { return _currentView; }
        set
        {
            if (value != _myCurrentView)
            {
                _myCurrentView = value;
                RaisePropertyChanged(); // You need to implement INotifyPropertyChanged interface
            }
        }
    }
