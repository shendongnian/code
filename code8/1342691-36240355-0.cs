    public int insertLocation (string name)
    {
        try
        {
            dataconnection.insertStatements(cmd);  
        }    
        catch
        {
            throw; // Here i'm getting error
        }
    }
