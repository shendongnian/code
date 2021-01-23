    public String TxtDocName
    {
        get { return _myModelItem.Name; }
        set
        {
            _myModelItem.Name = value;
            SetProperty(ref _txtDocName, value);
        }
    }
