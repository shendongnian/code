    protected override void Verify(Exception exception)
    {
        if (exception.IsAssignableFrom(expectedExceptionType.GetType()))
        {
    
        }
        //Some other code
    }
