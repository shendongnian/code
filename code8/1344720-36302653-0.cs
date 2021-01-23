    protected override void Verify(Exception exception)
    {
        if (expectedExceptionType.IsAssignableFrom(exception.GetType()))
        {
    
        }
        //Some other code
    }
