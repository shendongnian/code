    public bool ProcessIsRun()
    {
        Process[] proc = Process.GetProcesses();
        Return proc.Any(m => m.ProcessName.Contains("Your process name"));
    }
