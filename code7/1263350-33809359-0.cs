    public string Name
    { 
        get { return _name; }
        set
        {
            _name = value;
            NotifyOfPropertyChange(nameof(Name));
            // when Name changed, check if it is null or whitespace
            NotifyOfPropertyChange(nameof(CanSave));
        }
    }
