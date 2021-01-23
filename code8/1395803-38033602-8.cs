    public String TxtDocName
    {
        get { return _myModelItem.Name; }
        set
        {
            _txtDocName = value;
            _myModelItem.Name = _txtDocName;
            OnPropertyChanged();
        }
    }
