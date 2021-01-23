    Task[] tasks = new Task[IpAddressList.Count];
    for (int i = 0; i < IpAddressList.Count; i++)
    {
        Task<bool> task = SendHttpRequest(IpAddressList[i].ToString());
 
        tasks[i] = task;
    }
     
    await Task.WhenAll(tasks);
    for (int i = 0; i < tasks.Length; i++)
    {
        if (tasks[i].Result)
        {
            ListOfScannedIpAddresses.Add(IpAddressList[i].ToString());
        }
    }
