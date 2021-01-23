    if (BackgroundTaskRegistration.AllTasks.Any(task => task.Value.Name == TaskNameConst)) return;
    BackgroundTaskBuilder builder = new BackgroundTaskBuilder();
    builder.Name = TaskNameConst;
    builder.TaskEntryPoint = TaskEntryPointConst;
    builder.SetTrigger(new TimeTrigger(15, false));
    builder.Register();
