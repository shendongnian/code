        public class Root
        {
            [XmlElement("Geolocation")]
            List<Geolocation> Geolocation { get; set; }
        }
        public class Geolocation
        {
            [XmlElement("Latitude")]
            public double Latitude { get; set; }
            [XmlElement("Longitude")]
            public double Longitude { get; set; }
        }
