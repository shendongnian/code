    public class Root
    {
        public int room { get; set; }
        public Meta meta { get; set; }
        public Device[] devices { get; set; }
    }
    public class Meta
    {
    }
    public class Device
    {
        public Asset asset { get; set; }
        public string device_name { get; set; }
        public string device_type { get; set; }
        public string power_usage { get; set; }
        public Ui_Coordinates ui_coordinates { get; set; }
        public Transducers transducers { get; set; }
    }
    public class Asset
    {
        public string id { get; set; }
    }
    public class Ui_Coordinates
    {
        public string x { get; set; }
        public string y { get; set; }
        public string z { get; set; }
    }
    public class Transducers
    {
        public string relay { get; set; }
        public string dimmer { get; set; }
    }
