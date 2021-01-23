    void RunLongTask()
    {
         // long work to do
         // in case of wpf you can report progress to ui
         Dispatcher.Invoke(ProgressDelegate, 0);
         
         // more work
         Dispatcher.Invoke(ProgressDelegate, 1);
         // etc...
    }
    async Task RunLongTaskAsync()
    {
        await Task.Factory.StartNew(RunLongTask, TaskCreationOptions.LongRunning);
    }
