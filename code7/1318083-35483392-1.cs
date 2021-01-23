    private BackgroundTaskRegistration RegisterTask(
                Type taskType,
                SystemTriggerType systemTriggerType,
                SystemConditionType systemConditionType = SystemConditionType.Invalid)
    {
        var builder = new BackgroundTaskBuilder();
    
        /// A string identifier for the background task.
        builder.Name = taskType.Name;
    
        /// The entry point of the task.
        /// This HAS to be the full name of the background task: {Namespace}.{Class name}
        builder.TaskEntryPoint = taskType.FullName;
    
        /// The specific trigger event that will fire the task on our application.
        builder.SetTrigger(new SystemTrigger(systemTriggerType, false));
    
        /// A condition for the task to run.
        /// If specified, after the event trigger is fired, the OS will wait for
        /// the condition situation to happen before executing the task.
        if (systemConditionType != SystemConditionType.Invalid)
        {
            builder.AddCondition(new SystemCondition(systemConditionType));
        }
    
        /// Register the task and returns the registration output.
        return builder.Register();
    }
