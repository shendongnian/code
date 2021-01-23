    Monitor.Enter(_lock);
    if (_executing) {   // Another thread is running ExecuteTask()
       Monitor.Wait(_lock);
       Monitor.Exit(_lock);
    } else {
      _executing = true;
      Monitor.Exit(_lock);
      try {
        ExecuteTask();
      } finally {
        Monitor.Enter(_lock);
        _executing = false;
        Monitor.PulsaAll(_lock);
        Monitor.Exit(_lock);
      }
    }
