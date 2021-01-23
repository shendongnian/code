    private bool isLoggedIn;
    public bool IsLoggedIn
    {
       get { return isLoggedIn; }
       set
       {
           isLoggedIn = value;
           OnPropertyChanged("IsLoggedIn");
       }
    }
