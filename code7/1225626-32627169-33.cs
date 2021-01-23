    private readonly Dictionary<TaskOptions, Action> actions =
        new Dictionary<TaskOptions, Action>
        {
            { TaskOptions.Print, Print },
            { TaskOptions.Save, Save },
            { TaskOptions.SendMail , SendMail }
        };
    ...
    var task = TaskOptions.Print | TaskOptions.Save;
    foreach (var enumValue in Enum.GetValues(typeof(TaskOptions)).Cast<TaskOptions>())
    {
        if (task.HasFlag(enumValue))
        {
            actions[enumValue]();
        }
    }
 
