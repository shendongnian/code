    public class VMJoin
    {
        [IPUniqueValidator(ShouldCheck = "ShouldCheck")]
        public string IpAddress { get; set; }
        public bool ShouldCheck { get; set; }
    }
    
    public class ServerJoin
    {
        [IPUniqueValidator(ShouldCheck = "ShouldCheck")]
        public string IpAddress { get; set; }
        public bool ShouldCheck { get; set; }
    }
