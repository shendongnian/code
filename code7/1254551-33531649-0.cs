    Task[] tasks = new Task[IpAddressList.Count];
    for (int i = 0; i < IpAddressList.Count; i++)
    {
        Task task = SendHttpRequest(IpAddressList[i].ToString());
        tasks[i] = task;
        task.Start();
    }
    Task.WaitAll(tasks);
