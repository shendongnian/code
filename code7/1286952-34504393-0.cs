    private string _property;
    public string Property
    {
        get{ return _property;}
        set{ _property = value;}
    }
    public MainWindowViewModel()
    {
        Property = "test";
    }
