    public Section this[int index]
    {            
        get {
            return (Section)base[index]; //loops here with index always [0]
        }
        set {
            base[index] = value;
        }
    }
