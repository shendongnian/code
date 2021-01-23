    public bool ShowHide
    {
        get { return showHide; }
        set { showHide = value;
        OnPropertyChanged("ShowHide"); }
    }
    public int newProperty
    {
        get { return _newProperty; }
        set { _newProperty = value;
        OnPropertyChanged("newProperty"); }
    }
    public string NewStringProp
    {
        get { return _NewStringProp; }
        set { _NewStringProp = value;
        OnPropertyChanged("NewStringProp"); }
    }
