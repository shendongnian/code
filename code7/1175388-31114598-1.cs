    public bool ProcessIsRun()
    {
        Process[] proc = Process.GetProcesses();
        Return proc.Any(m => m.ProcessName.Contains("Your process name") && m.Modules[0].FileName == "Your File Path" );
    }
