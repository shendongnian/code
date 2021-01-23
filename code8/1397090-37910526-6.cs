    [Serializable()]
    [System.Xml.Serialization.XmlRoot("gpx")]
    public class gpx {
        [System.Xml.Serialization.XmlElement("metadata")]
        public Metadata mData { get; set; }
        [System.Xml.Serialization.XmlElement("trk")]
        public TrackCollection tCollection { get; set; }
    }
    [Serializable()]
    public class Metadata {
        /// Fill in metadata elements here
    }
    [Serializable()]
    public class TrackCollection {
        [System.Xml.Serialization.XmlElement("name")]
        public string name { get; set; }
        [XmlArray("trkseg")]
        [XmlArrayItem("trkpt", typeof(TrackPart))]
        public TrackPart[] tPart { get; set; }
    }
    [Serializable()]
    public class TrackPart {
        [System.Xml.Serialization.XmlElementAttribute("lat")]
        public double lattitude { get; set; }
        [System.Xml.Serialization.XmlElementAttribute("lon")]
        public double longitude { get; set; }
        [System.Xml.Serialization.XmlElement("ele")]
        public int elapsed { get; set; }
        [System.Xml.Serialization.XmlElement("time")]
        public DateTime dateTime { get; set; }
    }
