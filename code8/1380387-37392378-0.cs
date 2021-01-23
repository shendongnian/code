    private string _myProperty;
    public string MyProperty {
        get { return _myProperty; };
        set 
        {
            _myProperty = value; 
            PerformSomeAction(); 
        }
    }
