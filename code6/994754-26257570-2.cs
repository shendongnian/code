    private void deviceMemory()
        {
            var memoryLimit = Windows.System.MemoryManager.AppMemoryUsageLimit;
            memoryLimit = (memoryLimit / 1024) / 1024;
            Debug.WriteLine("Device Memory Limit: "+memoryLimit+"MB");
        }
