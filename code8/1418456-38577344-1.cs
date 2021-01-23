    public class Device
    {
        [Key]
        public int ID { get; set; }
        public int Name { get; set; }
        // if it must be a string, you can use this.
        // public string Type{ get; set; }
    
        //I personally prefer this approach
        public DeviceType Type { get; set; }
    }
    public enum DeviceType
    {
        Blade = 1, 
        Engine = 2,
        Diode = 3,
    }
