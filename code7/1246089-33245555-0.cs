    ...
    public string Name
    {
        get { return _name; }
        set 
        { 
            if (SetField(ref _name, value, "Name"))
                MyMethod();
        }
    }
    ...
