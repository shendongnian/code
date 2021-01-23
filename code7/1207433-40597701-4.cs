    public static long GetPrivateWorkingSetForAllProcesses(string ProcessName)
    {
      long totalMem = 0;
      Process[] process = Process.GetProcessesByName(ProcessName);
      foreach (Process proc in process)
      {
        long memsize = GetProcessPrivateWorkingSet64Size(proc.Id);
        totalMem += memsize;
      }
      return totalMem;
    }
