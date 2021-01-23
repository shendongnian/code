    bool lockTaken = Monitor.TryEnter(sync);
    try
    {
      if (lockTaken) 
      {
          // You're here - do your work
      }
      else
      {
          // Something else was in the thread - exit?
          return;
      }
    }
    finally
    {
       if (lockTaken) Monitor.Exit(sync);
    }
