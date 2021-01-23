        public static bool TryGetInstanceName(Process process, out string instanceName)
        {
            PerformanceCounterCategory processCategory = new PerformanceCounterCategory(_categoryName);
            string[] instanceNames = processCategory.GetInstanceNames();
            foreach (string name in instanceNames)
            {
                if (name.StartsWith(process.ProcessName))
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
            }
            instanceName = null;
            return false;
        }
