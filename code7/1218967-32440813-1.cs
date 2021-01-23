    OutData DoMath(InData data)
    {
      // First, take a context from the pool.
      var lazyContext = Pool.Take();
      try
      {
        // Initialize the context if necessary.
        var context = lazyContext.Value;
        return ... // Do the actual work.
      }
      finally
      {
        // Ensure the context is returned to the pool.
        Pool.Add(lazyContext);
      }
    }
