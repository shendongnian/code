    public void Intercept(IInvocation invocation)
    {
        queue.Enqueue(invocation.Proceed);
        ...
    }
