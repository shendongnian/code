    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/CSRedAlert.Core.Classes")]
    [KnownType(typeof(WindowShutter))]
    [KnownType(typeof(Sensor))]
    public class Device
    {
        [DataMember]
        public int I2C_Slave_Address { get; set; }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string ImagePath { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Pin { get; set; }
    }
    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/CSRedAlert.Core.Classes")]
    public class WindowShutter : Device
    {
        [DataMember]
        public string SecondaryPin { get; set; }
    }
    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/CSRedAlert.Core.Classes")]
    public class Sensor : Device
    {
    }
    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/CSRedAlert.Core.Classes")]
    public class Home
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public List<Room> Rooms { get; set; }
    }
    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/CSRedAlert.Core.Classes")]
    public class Room
    {
        [DataMember]
        public string Color { get; set; }
        [DataMember]
        public List<Device> Devices { get; set; }
        [DataMember]
        public int I2C_SlaveAdress { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
