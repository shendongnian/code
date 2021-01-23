    public void SomeMethod()
    {
        try
        {
            ...
        }
        catch(...)
        {
            ...
            return;
        }
        ... // this code will not run in case of exception in try block
    }
