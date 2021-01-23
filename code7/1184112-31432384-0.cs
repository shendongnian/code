        private List<PerformanceCounter> pclist = new List<PerformanceCounter>();
        private void GetProcessesMemoryUsage()
        {
            // if our list is empty, populate
            if (pclist.Count == 0)
            {
                // this takes around 300 ms on my box after running this a couple of times
                foreach (Process p in Process.GetProcesses())
                {
                    if (File.Exists(p.MainModule.FileName))
                    {
                        Process[] processes = Process.GetProcessesByName(p.ProcessName);
                        PerformanceCounter performanceCounter = new PerformanceCounter();
                        performanceCounter.CategoryName = "Process";
                        performanceCounter.CounterName = "Working Set";
                        performanceCounter.InstanceName = processes[0].ProcessName;
                        pclist.Add(performanceCounter);
             
                    }
                }
            }
            // this takes only around 80 msec on my box
            foreach(var pc in pclist)
            {
                 memoryUsage = ((uint)pc.NextValue() / 1024).ToString("N0");
            }
           
        }
