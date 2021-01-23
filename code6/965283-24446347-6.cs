    // somewhere in your code...
    WrapException( () =>
    {
        // read and parse lines...
    }, (ex) =>
    {
        WrapException(ex, ParseToExceptionFunction, HandleExceptionParseFunction, false);
    }, false);
    void WrapException(Action func, Action<Exception> handleCatch, bool rethrow)
    {
        try
        {
            func();
        }
        catch(Exception ex)
        {
            handleCatch(ex);
            
            if (rethrow)
                throw;
        }
    }
    static void WrapException<T>(T arg, Action<T> func, Action<Exception> handleCatch, bool rethrow)
    {
        try
        {
            func(arg);
        }
        catch (Exception ex)
        {
            handleCatch(ex);
            if (rethrow)
                    throw;
        }
    }
    void ParseToExceptionFunction(ArgType arg)
    {
        // try to parse to excetion
    }
    void HandleExceptionParseFunction(Exception ex)
    {
        // handle the exception for parsing the line with the exception
    }
