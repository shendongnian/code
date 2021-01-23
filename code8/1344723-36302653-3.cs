    protected override void Verify(Exception exception)
    {
        if (exception.GetType().IsAssignableFrom(expectedExceptionType))
        {
    
        }
        //Some other code
    }
