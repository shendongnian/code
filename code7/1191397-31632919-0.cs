     public string Password{
      get{ return _password;}
      set{
         _password = value;
         NotifyOfPropertyChange();
         NotifyOfPropertyChange(() => CanLogin);   // <--- Addition
       }
     } 
