     public static void KillProcess(string processName)
     {
       var process = Process.GetProcessesByName(processName);
       foreach (var proc in process)
         proc.Kill();
     }
