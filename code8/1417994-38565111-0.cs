    private string _someProperty = "";
    public string SomeProperty
    {
        get
        {
            return _someProperty;
        }
        set
        {
            if ( _someProperty != value )
            {
               _someProperty = value;
               RaisePropertyChanged();
            }
        }
    }
