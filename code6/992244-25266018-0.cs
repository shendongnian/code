    private static void Killprocess(string processName, string expectedCommandLine)
    {
        foreach (Process proc in Process.GetProcessesByName(processName).OrderBy(x => x.Id))
        {
            var commandLine = GetCommandLine(proc);
            if (commandLine.Contains(expectedCommandLine))
            {
                proc.Kill();
            }
        }
    }
    private static string GetCommandLine(Process process)
    {
        string wmiQuery = string.Format("select CommandLine from Win32_Process where ProcessId={0}", process.Id);
        ManagementObjectSearcher searcher = new ManagementObjectSearcher(wmiQuery);
        ManagementObjectCollection result = searcher.Get();
        return result.Cast<ManagementObject>()
            .Select(x => x["CommandLine"].ToString())
            .FirstOrDefault();
    }
    private static void Main()
    {
        Killprocess("winword", yourfullFilePath);
    }
