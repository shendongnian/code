    private bool _isOpen;
    public bool IsOpen
    {
        get
        {
            return _isOpen;
        }
        set 
        {
            _isOpen = value;
            OnPropertyChanged("IsOpen");
        }
    }
    public void OpenPopupExecute(object parameter)
    {
        IsOpen = true; // Will call OnPropertyChanged in setter
    }
