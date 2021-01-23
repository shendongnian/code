    // Start the periodic task, with a signal that we can use to stop it.
    var stop = new TaskCompletionSource<object>();
    var periodicTask = PeriodicallyReleaseAsync(stop.Task);
    // Wait for all item processing.
    await Task.WhenAll(taskList);
    // Stop the periodic task.
    stop.SetResult(null);
    await periodicTask;
