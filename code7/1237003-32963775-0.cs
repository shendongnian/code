    public void SomeMethod(CancellationToken token)
    {
      int waitResult;
      while ((waitResult = WaitHandle.WaitAny(
          new [] { yourEvent, token.WaitHandle }, POLLING_INTERVAL)) == WaitHandle.WaitTimeout)
      {
        if (IsShutdownRequested())
        {
          // Add code to end gracefully here.
        }
      }
      if (waitResult == 0)
      {
          // Your event was signaled so now we can proceed.
      }
      else if (waitResult == 1)
      {
          // The wait was cancelled via the token
      }
    }
