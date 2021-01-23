    public string ResolvedFirstName {
        get { return string.IsNullOrEmpty(FirstName) ? FirstName2 : FirstName; }
    }
    public string FirstName {
        get {...}
        set {...
            RaisePropertyChanged("FirstName");
            RaisePropertyChanged("ResolvedFirstName");}
    }
    public string FirstName2 {
        get {...}
        set {...
            RaisePropertyChanged("FirstName2");
            RaisePropertyChanged("ResolvedFirstName");}
    }
