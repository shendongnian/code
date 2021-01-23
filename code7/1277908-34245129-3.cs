    public static TResult InvokeMethod<TResult>
            (Func<TResult> func, ICollection<Type> ignoredExceptions)
    {
        try
        {
            return func();
        }
        catch (Exception ex)                         
            when (ignoredExceptions != null &&                    
                  ignoredExceptions.Any(t => t.IsAssignableFrom(ex.GetType()))) // C# 6 exception filter
        {
            return default(TResult);
        }
    }
