    public class PhysicalMemory 
    { 
        public ulong Capacity { get; internal set; } 
    	public ulong CapacityMB { get { return Capacity / (1024 * 1024); } } 
    	public ulong CapacityKB { get { return Capacity / 1024; } } 
    }
