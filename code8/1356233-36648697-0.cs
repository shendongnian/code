    object _lock = new object();
    void SomeBlockingMethod()
    {
        lock(_lock)
            Monitor.Wait(_lock);
        ... // here only after pulse
    }
    void SomeUnblockingMethod()
    {
        lock(_lock)
            Monitor.Pulse(_lock);
    }
