    public bool IsBusy
    {
        get
        {
            return _isBusy;
        }
        set
        {
            if(value!=_isBusy)
            {
                _isBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }
    }
