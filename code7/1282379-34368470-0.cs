    public interface MIB_OWNER_PID
    {
        public uint state {get; set; }
        public uint localAddr { get; set; }
        public byte[] localPort { get; set; }
        public uint remoteAddr { get; set; }
        public byte[] remotePort { get; set; }
        public uint owningPid { get; set; }
    }
