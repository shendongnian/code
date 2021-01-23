    void DoWMICall(string computer)
    {
        Console.WriteLine("Calling {0}", computer);
        Task.Delay(1000).Wait();
        Console.WriteLine("Computer {0} is OK", computer);
    }
    void CallComputers()
    {
        var tasks = new Task[100];
        var computerNames = new string[100];
        for (int i = 0; i < 100; ++i)
        {
            computerNames[i] = Guid.NewGuid().ToString();
        }
        for (int i = 0; i < 100; ++i)
        {
            var index = i;
            tasks[index] = Task.Run(() => DoWMICall(computerNames[index]));
        }
        // This call blocks until all tasks are finished.
        Task.WaitAll(tasks);
    }
