    Monitor.Enter(obj);
    try
    {
        // This would be the code inside the "lock" block
    }
    finally
    {
        if(Monitor.IsEntered(obj))
           Monitor.Exit(obj); // <-- This is how a Monitor releases the lock
    }
