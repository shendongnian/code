    private string mMyProperty;
    public string MyProperty
    {
        get { return mMyProperty; }
        set
        {
            mMyProperty = value;
            PerformSomeAction();
        }
    }
