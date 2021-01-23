    public static TResult InvokeMethod<TResult>
            (Func<TResult> func, ICollection<Type> ignoredExceptions)
    {
        try
        {
            return func();
        }
        catch (Exception ex) 
            when (ignoredExceptions != null &&
                  ignoredExceptions.Any(t => t.IsAssignableFrom(ex.GetType())))
        {
            return default(TResult);
        }
    }
