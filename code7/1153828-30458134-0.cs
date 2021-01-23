    public GetUserById(User user)
    { 
       //abc 
       // a long running task 
       Task.Run(()=> doLongRun());
       return user;
    }
    
    
    public void doLongRun()
    {
        try
        {
        }
        catch(Exception e)
        {
            // handle error
        }
    }
