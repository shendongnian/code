    public class Device
    {        
            [NonSerialized]
            public int DeviceId { get; set; }
            public string DeviceTokenIds { get; set; }
            public byte[] Data { get; set; }
            public string FilePwd { get; set; }        
    }
