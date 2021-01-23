    protected String _txtDocName;
    public String TxtDocName
    {
        get { return _myModelItem.Name; }
        set
        {
            SetProperty(ref _txtDocName, value);
            _myModelItem.Name = _txtDocName;
        }
    }
