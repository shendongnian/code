    bool _hasChanged = false;
    
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            if (value != _name)
            {
                _name = value;
                _hasChanged = true;
            }
        }
    }
