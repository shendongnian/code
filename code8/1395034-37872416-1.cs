    public string Location2Filter
    {
        get { return _Location2Filter; }
        set
        {
            if (_Location2Filter != value) {
                Set(ref _Location2Filter, value);
                UpdateLocation1();
            }
        }
    }
