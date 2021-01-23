    public void StartServiceCode(object state)
    {
      bool stopTimer = false;
      try
      {
        LogManager.GetLogger("MyLog").Info("Locking");
        lock (thisLock) {
          LogManager.GetLogger("MyLog").Info("Throwing");
          throw new ApplicationException();
        }
      } catch (Exception e) {
        // The lock is relased automatically
        // Logging the error (best practice)
        LogManager.GetLogger("MyLog").Info("Exception occurred...");
        // If severe, we need to stop the timer
        if (e is StackOverflowException || e is OutOfMemoryException) stopTimer = true;
      } finally {
        // Always clean up
        LogManager.GetLogger("MyLog").Info("finally");
      }
      // Do we need to stop?
      if (stopTimer) {
        LogManager.GetLogger("MyLog").Info("Severe exception : stopping");
        // You need to keep a reference to the timer. (yes, a timer can stop itself)
        timer.Stop();
      }
    }
