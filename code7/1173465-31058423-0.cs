    public ObservableCollection<SomeClass> SomeProperty
    {
        get
        {
            return _someProperty;
        }
        set
        {
            if (_someProperty = value) return;
            _someProperty = value;
            OnPropertyChanged("SomeProperty");
        }
    }
