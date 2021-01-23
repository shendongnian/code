    public async Task WaitAndThrowAsync()
    {
    	await Task.Delay(1000);
    	throw new Exception("yay");
    }
    public async Task CallWaitAndThrowAsync()
    {
        try
        {
            await WaitAndThrowAsync(); 
        }
        catch (Exception e)
        {
           // Do something. 
        }
    }
