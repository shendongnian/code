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
        Task aTask = Task.Run((Action)ProcessA); //You could also call use Task.Run(() => ProcessA());
        Task bTask = Task.Run((Action)ProcessB);
        aTask.Wait();
        bTask.Wait();
    }
