    public class ThinDevice
    {
        public string A { get; set; }
    }
    
    public class Device1 : ThinDevice
    {
        public string B { get; set; }
    }
    
    [HttpGet]
    public ThinDevice Get()
    {
        return GetDeviceResponse(new Device1 { A = "A", B = "B" });
    }
    
    private ThinDevice GetDeviceResponse<T>(T device) where T : ThinDevice
    {
        return new ThinDevice
        {
            A = device.A
        };
    }
