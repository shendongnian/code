    private DateTime _dateInViewModel;
    public DateTime DateInViewModel
    {
        get { return _dateInViewModel; }
        set
        {
            _dateInViewModel = value;
            NotifyPropertyChanged("DateInViewModel");
        }
    }
