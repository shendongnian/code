    private Status status;
    public Status Status
    {
        get{return status;}
        set
        {
            if (status != value)
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }
    }
