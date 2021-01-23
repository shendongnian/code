    public RelayCommand ButtonClickCommand
    {
        get
        {
            return _buttonClickCommand ??
                (_buttonClickCommand =
                    new RelayCommand(() => OnButtonClick()));
                }
        set 
        { 
            _buttonClickCommand = value; 
        }
    }
