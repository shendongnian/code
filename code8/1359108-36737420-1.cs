    private Visibility myProperty
    public Visibility MyProperty
    {
       get {return myProperty;}
       set {myProperty = value;NotifyPropertyChanged("MyProperty");}
    }
