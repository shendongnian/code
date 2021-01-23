    public string UserNameToShow
    {
        get 
        {
            if( this.username == null )
            {
                return "anonymous";
            }
    
            return this.username;
         }
    }
