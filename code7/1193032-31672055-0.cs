    List<Task> tasks  = new List<Task>();
    while(!parser.EndOfData)
    {
        tasks.Add(Task.Run(() => WriteTodb(tablename, set)));
    }
    Task.WaitAll(tasks.ToArray());
