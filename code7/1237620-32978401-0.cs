    for (int i = 0; i < 5; i++)
    {
        int k = i;
        Task tsk = Task.Factory.StartNew(() => DoSomething(k.ToString()));
        lstTasks.Add(tsk);
    }
