    private string name;
    public string MyName {
        get {
            return name;
        }
        set {
            name = (value == null)
                ? "Anonymous" : value;
        }
    }
