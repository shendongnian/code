    public static bool TryGetInstanceName(Process process, out string instanceName)
    {
        PerformanceCounterCategory processCategory = new PerformanceCounterCategory(_categoryName);
        string processName = Path.GetFileNameWithoutExtension(process.ProcessName);
        string[] instanceNames = processCategory.GetInstanceNames()
                .Where(inst => inst.StartsWith(processName))
                .ToArray();
        foreach (string name in instanceNames)
        {
                using (PerformanceCounter processIdCounter = new PerformanceCounter(_categoryName, _processIdCounter, name, true))
                {
                    if (process.Id == (int)processIdCounter.RawValue)
                    {
                        instanceName = name;
                        return true;
                    }
                }
        }
        instanceName = null;
        return false;
    }
