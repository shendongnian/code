    private string _email;
    public string Email 
    { 
       get{
           return _email;
        }
       set
       {
         this._email = value.ToUpper();
       }
    }
