    public class RootObject
	{
		public Device[] Devices { get; set; }
	}
	public class Device
	{
		public string HardwareID { get; set; }
		public string Count { get; set; }
		public string Class { get; set; }
		public Properties Properties { get; set; }
		public string DeviceType { get; set; }
		public string Description { get; set; }
	}
	public class Properties
	{
		public string CPUIDBrandString { get; set; }
		public string CPUIDString { get; set; }
		public string CPUIDMultithreading { get; set; }
		public string CPUIDBrandID { get; set; }
		public string CPUIDExtFamily { get; set; }
		public string CPUIDExtModel { get; set; }
		public string CPUIDSteppingID { get; set; }
		public string CPUIDNumberOfCores { get; set; }
		public string CPUIDLogicalCPUCount { get; set; }
		public string CPUIDFamily { get; set; }
		public string CPUIDVMExt { get; set; }
		public string CPUCount { get; set; }
		public string CPUIDProcessorID { get; set; }
		public string IsNuma { get; set; }
		public string CPUIDType { get; set; }
		public string Cpu_Temperature { get; set; }
		public string CPUIDCapable64bit { get; set; }
		public string CPUIDModel { get; set; }
	}
