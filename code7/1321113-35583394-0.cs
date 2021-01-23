    public class MyDevice
    {
        public MyDevice(string serial, int patientid)
        {
            ds = new DeviceSettings();
        }
    
        public DeviceSettings ds{ get; private set; }
    }
