    public async void MyMethod()
    {
        try
        {
            await ExceptionMethod();
        }
        catch (Exception ex)
        {
            // got it
        }
    }
    
    public async Task ExceptionMethod()
    {
        throw new Exception();
    }
