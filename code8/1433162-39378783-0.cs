    private static Random rnd = new Random();
    private static object sync = new object();
  
    static void Main(string[] args)
    {
        List<Task> tasks = new List<Task>();
        // Execute the task 10 times.
        for (int ctr = 1; ctr <= 5; ctr++)
        {
            tasks.Add(Task.Factory.StartNew(FirstWorldTask));
            Thread.Sleep(10);
        }
        Task.WaitAll(tasks.ToArray());
    }
  
    private static void FirstWorldTask()
    {
        string loggerName = "Logger";
        string randomName = rnd.Next().ToString(); //or GUID
        string targetFileName = "File";
        string targetMemoryName = "Memory";
  
        lock (sync)
        {
            //or using threadid here?
            loggerName += randomName;
            targetFileName += randomName;
            targetMemoryName += randomName;
            Console.WriteLine(loggerName);
        }
  
        var MB20 = 20 * 1024 * 1024;
        var fileTarget = new FileTarget(targetFileName)
        {
            ArchiveAboveSize = MB20,
            Layout = "${message}",  //probably you need more here
            FileName = "./" + randomName + "/logfile.txt",
  
  
        };
  
        LogManager.Configuration.AddTarget(fileTarget);
        LogManager.Configuration.AddRule(LogLevel.Info, LogLevel.Fatal, fileTarget, loggerName); //filter on loggerName;
  
  
        var memTarget = new MemoryTarget(targetMemoryName)
        {
            Layout = "${message}", //probably you need more here
        };
  
        LogManager.Configuration.AddTarget(memTarget);
        LogManager.Configuration.AddRule(LogLevel.Info, LogLevel.Fatal, memTarget, loggerName); //filter on loggerName;
  
  
  
        var m_log = LogManager.GetLogger(loggerName);
  
  
        for (int i = 0; i < 5; i++)
        {
            m_log.Info(i + " " + randomName);
            Thread.Sleep(10);
        }
  
        StringBuilder stringBuilder = new StringBuilder();
  
        foreach (var loggingEvent in memTarget.Logs)
        {
            stringBuilder.AppendLine(loggingEvent);
        }
        memTarget.Logs.Clear();
  
        Console.WriteLine(stringBuilder.ToString());
    }
