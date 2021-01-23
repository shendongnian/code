    public async Task getCPUInfo()
    {
        PerformanceCounter cpuCounter;
        cpuCounter = new PerformanceCounter();
        cpuCounter.CategoryName = "Processor";
        cpuCounter.CounterName = "% Processor Time";
        cpuCounter.InstanceName = "_Total";
        // Get Current Cpu Usage
        cpuCounter.NextValue();
        // Delay
        await Task.Delay(1000);
        // Get Current Cpu Usage again
        string currentCpuUsage = cpuCounter.NextValue() + "%";
        //Print it to the current label
        CPUUsage.Content = currentCpuUsage;
    }
