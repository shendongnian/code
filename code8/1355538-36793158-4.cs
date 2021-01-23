    public class VMJoin
    {
        [IPUniqueValidator]
        public string IpAddress { get; set; }
        public bool ShouldCheck { get; set; }
    }
    
    public class ServerJoin
    {
        [IPUniqueValidator]
        public string IpAddress { get; set; }
        public bool ShouldCheck { get; set; }
    }
