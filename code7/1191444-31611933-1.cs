    public bool IsSit
    {
        get
        {
            return ExtType == 1 || ExtType == 3;
        }
    }
    
    public bool IsStand
    {
        get
        {
            return ExtType == 2 || ExtType == 3;
        }
    }
    
    private int _extType;
    public int ExtType
    {
        get
        {
            return _extType;
        }
    
        set
        {
            _extType = value;
            RaisePropertyChanged("IsSit");
            RaisePropertyChanged("IsStand");
        }
    }
