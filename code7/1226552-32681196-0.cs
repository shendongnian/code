    private float GetActuratePrivateWorkingSet(Process currentProcess)
        {
            // get the physical mem usage for this process
            var pc = new PerformanceCounter("Process", "Working Set - Private", currentProcess.ProcessName, true);
            pc.NextValue();
            Thread.Sleep(1000);
            var privateWorkingSet = pc.NextValue()/ 1024/1024;
            return privateWorkingSet;
        }
