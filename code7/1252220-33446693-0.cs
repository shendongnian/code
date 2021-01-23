    public int Top
    {
        get
        {
            return Y - (Height / 2);
        }
        set
        {
            Y = value + (Height / 2);
        }
    }
