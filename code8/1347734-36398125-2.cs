    object _lock = new object();
    SomeEvent += (s, e) =>
    {
        lock(_lock)
        {
            Monitor.PulseAll(_lock); // pulse any (if any) awaiting events
            if(!Monitor.Wait(_lock, 5000)) // delay
            {
                ... // call event handler
                    // we are here if timeout is expired
            }
        }
    }
