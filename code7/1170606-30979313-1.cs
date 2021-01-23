    [OptionalPhone]
    [MaxLength(24)]
    public string PhoneNum1
    {
        get { return phoneNum1; }
        set
        {
            if (phoneNum1 != value)
            {
                phoneNum1 = value;
                RaisePropertyChanged("PhoneNum1");
            }
        }
    }
