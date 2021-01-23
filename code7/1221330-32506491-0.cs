    // 1. a public variable
    public int Money;
    
    // 2. an auto-implemented, or implicit property (very much like the above)
    public int Money { get; set; }
    
    // 3. An explicit property declaration with a private variable
    private int _money;
    
    public int Money {
        get {return _money;}
        set {
            _money = value;
    
            // possibly do something else here
        }
    }
