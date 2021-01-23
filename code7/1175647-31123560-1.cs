    private CompositeCollection _MyCompositeCollection;
    
    public CompositeCollection MyCompositeCollection
    {
        get { return _MyCompositeCollection; }
        set { _MyCompositeCollection = value; OnPropertyChanged("MyCompositeCollection"); }
    }
    
