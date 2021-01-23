    public bool IsValid
    {
        get { return _isValid; }
        set
        {
            _isValid = value;
            MyNewTextColorProperty = _isValid ? Color.Blue : Color.Red;
            
            OnPropertyChanged();
        }
    }
