    Task.Factory.StartNew(() => // <-- This starts a task which may or may not be on a 
                                // separate thread. It is non-blocking, and as such, code 
                                // after it is likely to execute before the task starts
    {
      BeginInvokeOnMainThread(() => scannerView.StartScanning(result =>
      // This invokes a method on the main thread, which may or may not be the current thread
      // Again, it's non-blocking, and it's very likely code after this will execute first
      {
    
          if (!ContinuousScanning)
          {
              Console.WriteLine("Stopping scan...");
              scannerView.StopScanning();
          }
    
          var evt = this.OnScannedResult;
          if (evt != null)
              evt(result);
    
          Console.WriteLine("Some output 1"); // <-- This output is executed once the entire
                                              // task has been completed, which is I believe
                                              // what you're looking for
      }, this.ScanningOptions));
    
      Console.WriteLine("Some output 2");
    });
    
    Console.WriteLine("lambda finished...");
