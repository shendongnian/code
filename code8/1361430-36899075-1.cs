    public sealed class MemoryInfo : IDisposable
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetPhysicallyInstalledSystemMemory(out ulong memoryInKilobytes);
        private readonly PerformanceCounter availableCounter;
        private readonly PerformanceCounter modifiedCounter;
        private readonly PerformanceCounter freeCounter;
        private readonly PerformanceCounter standbyCoreCounter;
        private readonly PerformanceCounter standbyNormalCounter;
        private readonly PerformanceCounter standbyReserveCounter;
        private ulong osTotalMemory;
        public ulong ModifiedBytes { get; private set; }
        public ulong InUseBytes { get; private set; }
        public ulong StandbyBytes { get; private set; }
        public ulong FreeBytes { get; private set; }
        public ulong HardwareReserved { get; }
        public MemoryInfo()
        {
            var computerInfo = new ComputerInfo();
            osTotalMemory = computerInfo.TotalPhysicalMemory;
            ulong installedPhysicalMemInKb;
            GetPhysicallyInstalledSystemMemory(out installedPhysicalMemInKb);
            this.HardwareReserved = installedPhysicalMemInKb * 1024 - osTotalMemory;
            modifiedCounter = new PerformanceCounter("Memory", "Modified Page List Bytes");
            standbyCoreCounter = new PerformanceCounter("Memory", "Standby Cache Core Bytes");
            standbyNormalCounter = new PerformanceCounter("Memory", "Standby Cache Normal Priority Bytes");
            standbyReserveCounter = new PerformanceCounter("Memory", "Standby Cache Reserve Bytes");
            freeCounter = new PerformanceCounter("Memory", "Free & Zero Page List Bytes");
            availableCounter = new PerformanceCounter("Memory", "Available Bytes");
            Refresh();
        }
        public void Refresh()
        {
            ModifiedBytes = (ulong)modifiedCounter.NextSample().RawValue;
            StandbyBytes = (ulong)standbyCoreCounter.NextSample().RawValue +
                           (ulong)standbyNormalCounter.NextSample().RawValue +
                           (ulong)standbyReserveCounter.NextSample().RawValue;
            FreeBytes = (ulong)freeCounter.NextSample().RawValue;
            InUseBytes = osTotalMemory - (ulong) availableCounter.NextSample().RawValue;
        }
        public void Dispose()
        {
            modifiedCounter.Dispose();
            standbyCoreCounter.Dispose();
            standbyNormalCounter.Dispose();
            standbyReserveCounter.Dispose();
            freeCounter.Dispose();
            availableCounter.Dispose();
        }
    }
