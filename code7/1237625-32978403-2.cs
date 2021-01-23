    for (int i = 0; i < 5; i++)
    {
        Task tsk = Task.Factory.StartNew(() => DoSomething(i.ToString()));
        lstTasks.Add(tsk);
        Thread.Sleep(50);
    }
