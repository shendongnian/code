    public int A
    {
        get { return a; }
        set
        {
            if (value == a) return;
            a = value;
            OnPropertyChanged("A");
            OnPropertyChanged("D");
        }
    }
    
    public int B
    {
        get { return b; }
        set
        {
            if (value == b) return;
            b = value;
            OnPropertyChanged("B");
            OnPropertyChanged("D");
        }
    }
