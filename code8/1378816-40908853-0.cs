    public void CheckRights()
    {
        if(!service.UserHasRights())
        {
             Environment.Exit(1);
        }
    }
    internal virtual void Exit() 
    {
        Environment.Exit(1);
    }
