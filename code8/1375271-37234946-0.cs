    private string _name;
    public string name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
            PropertyChanged(this, new PropertyChangedEventArgs("name"));
        }
    }
