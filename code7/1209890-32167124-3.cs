    private List<string> _myCollection;
    
    public List<string> myCollection
    {
        get { return _myCollection; }
        set { _myCollection= value; OnPropertyChanged("myCollection"); }
    }
