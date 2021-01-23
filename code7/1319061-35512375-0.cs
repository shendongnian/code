    public TResult Spy<TResult>(Func<TResult> method)
    {
        methodCalls.Add(method.Method.Name);
        return method();
    }
    public TResult Spy<TArg, TResult>(Func<TArg, TResult> method, TArg arg)
    {
        methodCalls.Add(method.Method.Name);
        return method(arg);
    }
    public TResult Spy<TArg1, TArg2, TResult>
        (Func<TArg1, TArg2, TResult> method, TArg1 arg1, TArg2 arg2)
    {
        methodCalls.Add(method.Method.Name);
        return method(arg1, arg2);
    }
    ...
