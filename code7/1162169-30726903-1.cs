    // On a new thread
    try
    {
      InitializeProlog();
      try
      {
        myTs.RunOnCurrentThread();
      }
      finally
      {
        ReleaseProlog();
      }
    }
    catch (Exception ex)
    {
      // The global handler
    }
