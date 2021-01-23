    public async int SomeFuncAsync()
    {
        Exception ex=null;
        try
        {
            //do something
        }
        catch(Exception exc)
        {
            ex=exc;
        }
        if(ex!=null) await Task.Delay(1000); // no error
    }
