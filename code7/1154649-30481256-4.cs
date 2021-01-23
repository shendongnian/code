    public async int SomeFuncAsync()
    {
        try
        {
            //do something
        }
        catch
        {
            await Task.Delay(1000); //error
        }
    }
