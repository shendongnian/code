    public Visibility IsSendAvailable
    {
        get { return CanSend ? Visibility.Visible : Visibility.Collapsed; }
        set { _IsSendAvailable = value; OnPropertyChanged("IsSendAvailable"); }
    }
