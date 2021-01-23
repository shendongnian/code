    public async Task RegisterTask()
    {
        var backgroundAccessStatus = await BackgroundExecutionManager.RequestAccessAsync();
        if (backgroundAccessStatus == BackgroundAccessStatus.Denied) { return; }
        if (GetTask()) { return; }
        var timeTrigger = new TimeTrigger(15, false);
        var backgroundTaskBuilder = new BackgroundTaskBuilder();
        backgroundTaskBuilder.Name = TASK_NAME;
        backgroundTaskBuilder.TaskEntryPoint = typeof(BackgroundTileTimerTask.BackgroundTask).FullName;
        backgroundTaskBuilder.SetTrigger(timeTrigger);
        backgroundTaskBuilder.Register();
    }
