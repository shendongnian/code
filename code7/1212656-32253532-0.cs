    private bool _isReadOnly;
    public bool IsReadOnly
    {
        get { return _isReadOnly; }
        set
        {
            myinput.Disabled = value;
            _isReadOnly = value;
        }
    }
