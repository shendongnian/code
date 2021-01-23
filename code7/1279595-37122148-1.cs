    // container with a data property
    // this one is being serialized
    public class Root
    {
        public DeviceData data { get; set; }
    }
    public class DeviceData
    {
        public string IMEI { get; set; }
    }
    
    protected void CallIMEIVerfication()
    {
        JavaScriptSerializer ser = new JavaScriptSerializer();
        DeviceData data = new DeviceData() { IMEI = "352423061590616" };
        var root = new Root { data=data };
        string str = ser.Serialize(root);
        // rest of your code
    }
