    public void CatchEmAll()
    {
        try
        {
            DoSomethingExceptiony();
        }
        catch (Exception ex)
        {
            // handle the exception
        }
    }
    
    public void DoSomethingExceptiony()
    {
        throw new Exception("Uh oh!");
    }
