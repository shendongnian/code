    public int X {
        get {
            return x;
        }
        set {           
            x = value;
            OnPropertyChanged()
        }
    }
