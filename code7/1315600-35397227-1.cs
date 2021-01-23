    private string _clearPassword
    publuc string ClearPassword
    {
      get { return _clearPassword;}
      set
     { 
       _clearPassword = value;
        RaisePropertyChanged("ClearPassword");
      }
    }
