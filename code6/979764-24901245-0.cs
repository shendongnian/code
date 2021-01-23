    public class Device
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string HardwareRevision { get; set; }
        public string Id { get; set; }
    }
    public class Registry
    {
        public Dictionary<string, Device> Devices { get; set; }
    }
