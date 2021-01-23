    private string _state;
    public string State
    {
        get { return _state; }
        set
        {
            _state = value;
            RaisePropertyChanged("State");
        }
    }
