    private string _Thing;
    Public string Thing
    {
        get { return _Thing; }
        set { _Thing = value; }
       RaisePropertyChanged("Thing")
    }
