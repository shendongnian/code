    [XmlRoot("Registrations")]
    public class Registrations
    {
        [XmlElement("Registration")]
        public List<Registration> Regs { get; set; }
    }
