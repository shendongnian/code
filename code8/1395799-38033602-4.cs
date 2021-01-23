    public String TxtDocName
    {
        get { return _myModelItem.Name; }
        set
        {
            _myModelItem.Name = _txtDocName;
            SetProperty(ref _txtDocName, value);
        }
    }
