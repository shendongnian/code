    public override void CanClose(Action<bool> callback)
    {
        if (BackTestCollection.Any(bt => bt.TestStatus == TestStatus.Running))
        {
            // Update running test.
            var cleanupTask = Task.Run(async () =>
            {
                StatusMessage = "Stopping running backtest...";
                await SaveBackTestEventsAsync(SelectedBackTest);
                // other cleanup  tasks
                // No continuation
                StatusMessage = "Disposing backtest engine...";
                 if (engine != null)
                    engine.Dispose();
                 Log.Trace("Shutdown requested: disposed backtest engine successfully");
                 callback(true);
            });
            cleanupTask.Wait();
        }
    }
