    public override void CanClose(Action<bool> callback)
    {
        if (BackTestCollection.Any(bt => bt.TestStatus == TestStatus.Running))
        {
            // Update running test.
            var cleanupTask = Task.Run(async () =>
            {
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate { StatusMessage.Text = "Stopping running backtest..."; }));
                await SaveBackTestEventsAsync(SelectedBackTest);
                // other cleanup  tasks
                // No continuation
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate { StatusMessage.Text = "Disposing backtest engine..."; }));
                if (engine != null)
                    engine.Dispose();
                Log.Trace("Shutdown requested: disposed backtest engine successfully");
                callback(true);
            });
            while (!cleanupTask.IsCompleted)
            {
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate { }));
            }
        }
    }
