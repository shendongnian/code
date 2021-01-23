    bool _isEnabledSuspended;
    public bool IsEnabledSuspended
    {
        get { return _isEnabledSuspended; }
        set
        {
            _isEnabledSuspended = value;
            if(value)
                OnPropertyChanged(nameof(IsEnabled));
        }
    }
    bool _isEnabled;
    public bool IsEnabled
    {
        get { return _isEnabled; }
        set
        {
            if(!IsEnabledSuspended)
            {
                _isEnabled = value;
                OnPropertyChanged();
            }
        }
    }
