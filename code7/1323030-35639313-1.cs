    var tasks = new Task<MyReturnType>[mbis.Length];
    for (int i = 0; i < tasks.Length; i++)
    {
        tasks[i] = CAS.Service.GetAllRouterInterfaces(mbis[i], 3);
    }
    await Task.WhenAll(tasks);
