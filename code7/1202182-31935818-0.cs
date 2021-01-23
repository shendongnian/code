    public partial class Vehicles
    {
        [XmlElement("Vehicle")]
        public Vehicle[] Vehicle { get; set; }
    }
    [XmlInclude(typeof(Model))]
    public partial class Vehicle
    {
        public uint Id { get; set; }
    }
    public class Model : Vehicle { }
