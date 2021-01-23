    foreach (var task in BackgroundTaskRegistration.AllTasks)
    {
        task.Value.Unregister(true);
    }
    var result = await BackgroundExecutionManager.RequestAccessAsync();
    if (result == BackgroundAccessStatus.Denied)
    {
        return;
    }
    BackgroundTaskBuilder builder = new BackgroundTaskBuilder();
    builder.Name = "<task name>";
    builder.TaskEntryPoint = "<task entry point>";
    builder.SetTrigger(new SystemTrigger(SystemTriggerType.NetworkStateChange, false));
    var registration = builder.Register();
