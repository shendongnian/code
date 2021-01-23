    private short? _myProp;
    public short? MyProp
    {
        get
        {
            return _myProp;
        }
        set
        {
            if (value != null)
            {
                SomeProp = SomeWork(value);
                _myProp = value;
            }
        }
    }
