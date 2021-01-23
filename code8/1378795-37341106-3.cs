    private string _boxText;
    public string BoxText
    {
        get { return _boxText; }
        set
        {
            if (_boxText != value)
            {                    
                _boxText=CheckBoxText(value);
                RaisePropertyChanged("BoxText");
            }
        }
    }
