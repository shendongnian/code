    public SomeThing MyMethod()
    {
        return Execute(() =>
        {
            return new SomeThing();
        });
    }
    public T Execute<T>(Func<T> func)
    {
        if (func == null)
            throw new ArgumentNullException("func");
        try
        {
            Setup();
            return func();
        }
        finally
        {
            TearDown();
        }
    }
