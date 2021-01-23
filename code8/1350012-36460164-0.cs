    public string FirstName
    {
        get { return _FirstName; }
        set
        {
            ArgChecker.ThrowOnStringNullOrWhiteSpace(_FirstName);
            _FirstName = value; 
        }
    }
