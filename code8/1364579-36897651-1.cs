    public string Lastname
    {
        get { ... }      
        set 
        {
            if (_lastname.Equals(value))
                return;
            RaisePropertyChanged("Lastname");
            RaisePropertyChanged("Fullname");
        }
    }
