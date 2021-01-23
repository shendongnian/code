    private string name;
    public string MyName {
        get {
            return name;
        }
        set {
            if (value == null)
                name = "Anonymous";
            else 
                name = value;
        }
    }
