    private readonly Dictionary<TaskOptions, Action> actions =
        new Dictionary<TaskOptions, Action>
        {
            { TaskOptions.Print, Print },
            { TaskOptions.Save, Save },
            { TaskOptions.SendMail , SendMail }
        };
    ...
    task = TaskOptions.Print | TaskOptions.Save;
    foreach (var enumValue in Enum.GetValues(typeof(TaskOptions)))
    {
        if ((task & enumValue) == enumValue)
        {
            actions[enumValue]();
        }
    }
 
