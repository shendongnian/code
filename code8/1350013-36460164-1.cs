    public string FirstName
    {
        get { return _FirstName; }
        set
        {
            ArgChecker.ThrowOnStringNullOrWhiteSpace(value);
            _FirstName = value; 
        }
    }
