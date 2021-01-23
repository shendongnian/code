    object _lock = new object();
    SomeEvent += (s, e) =>
    {
        lock(_lock)
        {
            Monitor.PulseAll(_lock);
            if(!Monitor.Wait(_lock, 5000)) // delay
            {
                ... // call event handler
            }
        }
    }
