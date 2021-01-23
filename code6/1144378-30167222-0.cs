     [XmlRoot("SingleSensors")]
        public class SimpleSensor
        {
            [XmlElement("SSensor")]
            public List<SSensor> sSensor { get; set; }
        }
        [XmlRoot("PressureSensors")]
        public class PressureSensors
        {
            [XmlElement("PSensor")]
            public List<SSensor> sSensor { get; set; }
        }
