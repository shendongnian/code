    bool IJob<bool>.Trigger()
    {
        // do something and return a bool
    }
    public void Trigger()
    {
        (IJob<bool>(this)).Trigger();  // ignore the return value
    }
