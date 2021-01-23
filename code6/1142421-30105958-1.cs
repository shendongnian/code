    public Dictionary<UInt32, string> CurrentSamples
    {
        get { return models[key].samples; }
    }
    public string key
    {
        get { return _key; }
        set
        {
            _key = value;
            OnPropertyChanged("key");
            OnPropertyChanged("CurrentSamples");
        }
    }
