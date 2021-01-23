    public class DeviceContainer
    {
        public static List<DevTimer> timers=new List<DevTimer>();
    }
    public class DevTimer:Timer
    {
        public string Identifier {get; set;}
        public bool IsInUse{get; set;}
    }
