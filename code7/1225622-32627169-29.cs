    [Flags]
    public enum TaskOptions 
    {
        Print    = 1,
        Save     = 2,
        SendMail = 4,
        NewOption = 8,
    }
    task = TaskOptions.Print | TaskOptions.Save;
    if (task.HasFlag(TaskOptions.Print))
    { 
        print();
    }
    if (task.HasFlag(TaskOptions.Save))
    { 
        save();
    }
    if (task.HasFlag(TaskOptions.SendMail))
    { 
        sendMail();
    }
    if (task.HasFlag(TaskOptions.NewOption))
    { 
        newOption();
    }
