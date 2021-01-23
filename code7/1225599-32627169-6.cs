    [Flags]
    public enum TaskOptions 
    {
        Print    = 1,
        Save     = 2,
        SendMail = 4,
        NewOption = 8,
    }
    task = TaskOptions.Print | TaskOptions.Save;
    if ((task & TaskOptions.Print) == TaskOptions.Print)
    { 
        print();
    }
    if ((task & TaskOptions.Save) == TaskOptions.Save)
    { 
        save();
    }
    if ((task & TaskOptions.SendMail) == TaskOptions.SendMail)
    { 
        sendMail();
    }
    if ((task & TaskOptions.NewOption) == TaskOptions.NewOption)
    { 
        newOption();
    }
