    public class NetshResult
    {
        public NetshResult(string[] columns)
        {
            PhysicalAddress = columns[0];
            IpAddress = columns[1];
            Type = columns[2];
            Interface = columns[3];
        }
        public string PhysicalAddress { get; private set; }
        public string IpAddress { get; private set; }
        public string Type { get; private set; }
        public string Interface { get; private set; }
    }
    public class WemoDevice
    {
        public string Address { get; set; }
        public uint Port { get; set; }
    }
