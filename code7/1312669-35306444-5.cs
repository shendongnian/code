    // Get a pooled task or create a new one. The task may
    // have already completed, in which case Result will
    // be available immediately. If the task is still
    // in flight, accessing its Result will block.
    Task<MyComponent> task = pool.Get();
    try
    {
        MyComponent component = task.Result; // Alternatively you can "await task"
        // Do something with component.
    }
    finally
    {
        pool.Return(task);
    }
