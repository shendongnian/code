    public string Location2Filter
    {
        get { return _Location2Filter; }
        set
        {
            Set(ref _Location2Filter, value);
            UpdateLocation1();
        }
    }
