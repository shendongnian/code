    public async Task<Object> Get()
    {
        object result = null;
        try
        {
            result = await methodThatThrowsException();
        }
        catch (Exception ex)
        {
            throw CreateHttpResponseException(ex);
        }
            return result;
    }
