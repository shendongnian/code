        /// <summary>
        /// 
        /// </summary>
        public void getCPUInfo()
        {
            PerformanceCounter cpuCounter;
            cpuCounter = new PerformanceCounter();
            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";
            // Get Current Cpu Usage
            cpuCounter.NextValue(); // Added
            System.Threading.Thread.Sleep(1000); // Added
            // now matches task manager reading 
            float secondValue = cpuCounter.NextValue(); // Added
            string currentCpuUsage = secondValue + "%";
            //Print it to the current label
            CPUUsage.Content = currentCpuUsage;
        }
