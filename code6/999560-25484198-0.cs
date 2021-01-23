    public string Name
    {
        get {return name;}
    }
    
    // Define Level property. 
    // This is a read-only attribute. 
    
    public string Level
    {
        get {return level;}
    }
    
    // Define Reviewed property. 
    // This is a read/write attribute. 
    
    public bool Reviewed
    {
        get {return reviewed;}
        set {reviewed = value;}
    }
