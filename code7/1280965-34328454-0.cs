    for (int i = 0; i < list.Count; i++)
    {
        int copy = i;
        Task task = new Task(() => DoWork(list[copy]));
        task.Start();
    }
