    try {
      Monitor.Enter(_lock);
      if (_executing)   // Another thread is running ExecuteTask()
         Monitor.Wait(_lock);
      else {
        _executing = true;
        try {
          ExecuteTask();
        } finally {
          _executing = false;
          Monitor.PulsaAll(_lock);
        }
      }
    } finally {
      Monitor.Exit(_lock);
    }
