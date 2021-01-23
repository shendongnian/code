    public class Device
    {
        [Key]
        public int ID { get; set; }
        public int Name { get; set; }
        public DeviceType Type { get; set; }
    }
    public enum DeviceType
    {
        Blade = 1, 
        Engine = 2,
        Diode = 3,
    }
