    void ProcessA()
    {
        ProcessA1();
        ProcessA2();
    }
    void ProcessB()
    {
        ProcessB1();
        ProcessB2();
    }
    void LaunchProcesses()
    {
        Task aTask = Task.Run(ProcessA);
        Task bTask = Task.Run(ProcessB);
        aTask.Wait();
        bTask.Wait();
    }
