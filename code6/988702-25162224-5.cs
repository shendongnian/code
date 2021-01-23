    public class Manufacturer
    {
        public string Name{ get; set; }
        public List<Motor> AvailaibleMotors{ get; set; }
        public string getClassSerialized()
        {
            return new JavaScriptSerializer().Serialize(this);
        }
    
        public ManufacturergetClassDeSerialized(string sSerializedClass)
        {
            return new JavaScriptSerializer().Deserialize<Manufacturer>(sSerializedClass);
        }
    }
    public class Motor
    {
        public string Model { get; set; }
        public List<Voltage> Voltages { get; set; }
    }
    public class Voltage
    {
        public int Volt { get; set; }
        public int Phase { get; set; }
        public int Frequency { get; set; }
    }
