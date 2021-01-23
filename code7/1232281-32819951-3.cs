    // For example:
    public string Text { get; set; }
    
    // is...
    private string _text;
    public string Text { get { return _text; } set { _text = value; } }
    
