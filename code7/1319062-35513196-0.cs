    public TResult Spy<TResult> (Func<TResult> method)
    {
        return Spy<TResult>((Delegate)method);
    }
    public TResult Spy<T1, TResult> (Func<T1, TResult> method, T1 arg1)
    {
        return Spy<TResult>((Delegate)method, arg1);
    }
    private TResult Spy<TResult> (Delegate method, params object[] args)
    {
        methodCalls.Add(method.Method.Name);
        return (TResult)method.Method.Invoke(method.Target, args);
    }
