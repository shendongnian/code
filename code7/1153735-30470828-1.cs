      // This TaskScheduler captures SynchronizationContext.Current.
      TaskScheduler taskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
      // Start a new task (this uses the default TaskScheduler, 
      // so it will run on a ThreadPool thread).
      Task.Factory.StartNew(() =>
      {
        // We are running on a ThreadPool thread here.
        // Do some work.
        // Report progress to the UI.
         Task reportProgressTask = Task.Factory.StartNew(() =>
           {
             // We are running on the UI thread here.
             // Update the UI with our progress.
           }, 
          s.Token, 
          TaskCreationOptions.None,
          taskScheduler);
        reportProgressTask.Wait();
      
        // Do more work.
      });
