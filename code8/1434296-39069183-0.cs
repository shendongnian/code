    public void Execute(Action f)
    {
        // check if f has a LogBeforeRunning attribute and log the text
        try
        {
            f();
        }
        catch
        {
            // check if f has a LogOnError attribute and log the text
        }
        // check if f has a LogAfterRunning attribute and log the text
    }
    public void Execute<T>(Action<T> f, T arg)
    {
        // check if f has a LogBeforeRunning attribute and log the text
        try
        {
            f(arg);
        }
        catch
        {
            // check if f has a LogOnError attribute and log the text
        }
        // check if f has a LogAfterRunning attribute and log the text
    }
    public void Execute<T1, T2>(Action<T1, T2> f, T1 arg1, T2 arg2)
    {
        // check if f has a LogBeforeRunning attribute and log the text
        try
        {
            f(arg1, arg2);
        }
        catch
        {
            // check if f has a LogOnError attribute and log the text
        }
        // check if f has a LogAfterRunning attribute and log the text
    }
    // ...
