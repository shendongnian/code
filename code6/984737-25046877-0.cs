     //1. Add a setter on the property, or : 
    public string Name
    {
        get { return _name; }
        internal set { _name = value; }
    }
    //2. Add a setter method for _name :
    internal void SetName(string value)
    {
        _name = value;
    }
