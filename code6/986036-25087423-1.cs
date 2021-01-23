    List<string> safeProcs = new List<string>() { "App1", "App2", "App3" };
    List<Process> procs = Process.GetProcesses()
        .Where(p => !p.Equals(Process.GetCurrentProcess()) && !safeProcs.Contains(p.ProcessName))
        .ToList();
    procs.ForEach(p => p.Kill());
