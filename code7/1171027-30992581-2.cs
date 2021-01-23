    public static void Main(string[] args)
    {
        // start core and extra tasks
        Task<string> coreDataTask = Task.Factory.StartNew(() => "core data" /* do something more complicated here */);
        List<Task<string>> extraDataTaskList = new List<Task<string>>();
        for (int i = 0; i < 10; i++)
        {
            int x = i;
            extraDataTaskList.Add(Task.Factory.StartNew(() => "extra data " + x /* do something more complicated here */));
        }
        // wait for core data to be ready first.
        StringBuilder coreData = new StringBuilder(coreDataTask.Result);
    
        // enrich core as the extra data tasks complete.
        while (extraDataTaskList.Count != 0)
        {
            int indexOfCompletedTask = Task.WaitAny(extraDataTaskList.ToArray());
            Task<string> completedExtraDataTask = extraDataTaskList[indexOfCompletedTask];
            extraDataTaskList.Remove(completedExtraDataTask);
            EnrichCore(coreData, completedExtraDataTask.Result);
        }
        Console.WriteLine(coreData.ToString());
    }
    
    private static void EnrichCore(StringBuilder coreData, string extraData)
    {
        coreData.Append(" enriched with ").Append(extraData);
    }
