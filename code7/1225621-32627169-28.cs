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
