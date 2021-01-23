    Task.Factory.StartNew(a, fPath,
        CancellationToken.None, TaskCreationOptions.None, // unfortunately, there is no easier overload with just the context...
        TaskScheduler.FromCurrentSynchronizationContext()).ContinueWith(
            t => { dataGridView2.DataSource = t.Result; },
            TaskScheduler.FromCurrentSynchronizationContext());
