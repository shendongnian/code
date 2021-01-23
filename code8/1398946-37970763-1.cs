    public override SomeReturnTypeItem LoginAsync()
    {
    #if __MOBILE__
        throw new NotSupportedException("Windows authentication is not supported in mobile version");
    #else
        return LoginAsyncImpl();
    #endif
    }
    private async SomeReturnTypeItem LoginAsync()
    {
        //some code
    } 
