    public GUI(...)
    {
        ...
        var task = CheckLoginState(username, password).Wait();
        if(task.IsFaulted && task.Exception != null)
        {
            throw task.Exception
        }
        ...
    }
