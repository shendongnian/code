    public static ProcessPacket Packet {get; set;} //Expose properties, not fields!
    public static void Main(string[] args)
    {
        log_lib.Log log = new log_lib.Log(2, 0, true, true);
        SockBase base2 = new SockBase(log);
        Packet = new ProcessPacket("configfile.cfg");
    }
