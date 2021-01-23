    private const string ExamplePropertieDefault = "default";
    [DefaultValue(ExamplePropertieDefault)]
    public String ExamplePropertie
    {
        get
        {
            return _myProp;
        }
        set
        {
            if (value == null)
                ExamplePropertieDefault;
            else
                _myProp = value;
            OnPropertyChanged(nameof(ExamplePropertie));
        }
    }
