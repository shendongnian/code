    while (true)
    {
        List<MyProgress> prog = new List<MyProgress>();
        procList = Process.GetProcesses().ToList();
        for (int i = 0; i < procList.Count; i++)
        {
            Process[] processes = Process.GetProcessesByName(procList[i].ProcessName);
            PerformanceCounter performanceCounter = new PerformanceCounter();
            performanceCounter.CategoryName = "Process";
            performanceCounter.CounterName = "Working Set - Private";//"Working Set";
            performanceCounter.InstanceName = processes[0].ProcessName;
            
            prog.Add(new MyProgress { Id = procList[i].ProcessName, Progress = ((uint)performanceCounter.NextValue() / 1024).ToString("N0")});
        }
        
        worker.ReportProgress(0, prog);
    }
