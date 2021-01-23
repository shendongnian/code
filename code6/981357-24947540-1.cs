    public String UserFirstName
    {
         get { return this._userFirstName; }
         set  
         {
             this._userFirstName = value;
             this.RaisePropertyChanged("UserFirstName");
         }
    }
