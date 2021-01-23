    public IInterface MyIntf
    {
        get { return _myIntf; }
        set
        {
            if (_myIntf.Equals(value)) { return; }
            _myIntf = value;
        }
    }
