    private ulong GetMaxAvailableRAM()
    {
        Microsoft.VisualBasic.Devices.ComputerInfo CI = new ComputerInfo();
        return CI.AvailablePhysicalMemory;            
    }
