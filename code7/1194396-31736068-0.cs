    public void M(string p)
    {
        if (p == null)
        {
            throw new ArgumentNullException(nameof(p));
        }
        ...
    }
    
    public int P
    {
        get
        {
            return p;
        }
        set
        {
            p = value;
            NotifyPropertyChanged(nameof(P));
        }
    }
