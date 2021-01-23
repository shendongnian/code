    public bool AgeWasSet { get; private set; }
    private int _age;
    public int Age 
    {
        get { return _age; }
        set { _age = value; AgeWasSet = true; }
    }
