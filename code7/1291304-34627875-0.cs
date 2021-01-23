    void MonitorReentrancy()
    {
        var obj = new object();
        lock (obj)
        {
            // Lock obtained. Must exit once to release.
            lock (obj) // Deadlock?
            {
                // Nope, we've just *re-entered* the lock.
                // Must exit twice to release.
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(obj, ref lockTaken); // Deadlock?
                    // Nope, we've *re-entered* lock again.
                    // Must exit three times to release.
                }
                finally
                {
                    if (lockTaken) {
                        Monitor.Exit(obj);
                    }
                    // Must exit twice to release.
                }
            }
            // Must exit once to release.
        }
            
        // At this point we have finally truly released
        // the lock allowing other threads to obtain it.
    }
