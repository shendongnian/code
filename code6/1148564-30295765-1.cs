    public static ReturnValue<T> TryMethod<T>(Func<ReturnValue<T>> method)
    {
       var methodResult = method();
       if (!methodResult .IsSuccesful)
           return new ReturnValue<T>(methodResult.ThrownException);
    
       // I can only guess at this:
       return methodResult;
    }
