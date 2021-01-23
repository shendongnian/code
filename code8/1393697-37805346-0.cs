    private string _MyNemericStringr;
    
    public string MyNemericString
    {
        get { return _MyNemericStringr; }
        set {
            if (value.All(char.IsDigit))
                _MyNemericStringr = value;
            else
                _MyNemericStringr = "0";
        }
    }
