    public int A
    {
        get { return a; }
        set
        {
            if (a != value)
            {
                a = value;
                OnPropertyChanged("A");
                B = value + 1;
                SomeAction();
            }
        }
    }
    private int a;
    
    public int B
    {
        get { return b; }
        set
        {
            if (b != value)
            {
                b = value;
                OnPropertyChanged("B");
                SomeAction();
            }
        }
    }
    private int b;      
