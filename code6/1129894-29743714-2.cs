    public bool BoolValue
    {
        get { return IntValue == 1; }
        set { IntValue = value ? 1 : 0;}
    }
    
    public int IntValue { get; set; }
