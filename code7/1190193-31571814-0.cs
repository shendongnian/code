    public List<string> ownedShips;
    
    public TESTPlayerAccount()
    {
        ownedShips = new List<string> ();
    }
    
    public List<string> Ships
    {
        get {return ownedShips;}
        set {ownedShips = value;}
    }
