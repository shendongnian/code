    public partial class Location {
        [XmlElement]
        public GPSPoint GPSPoint { get; set; }
        [XmlElement]
        public ImagePoint ImagePoint { get; set; }
    }
    public partial class GPSPoint {
        [XmlElement(ElementName = "Coordinate", Order = 0)]
        public Coordinate Coordinate1 {get; set; }
        [XmlElement(Order=1, ElementName="Coordinate")]
        public Coordinate Coordinate2 {get;set;}
    }
    public partial class Coordinate {        
        [XmlAttribute()]
        public ICoordinateType type {get;set;}
    }
    
    [Serializable]
    public enum ICoordinateType {        
        /// <remarks/>
        GpsCoordinateDegMinSec,        
        /// <remarks/>
        GpsCoordinateDeg,
    }
      public partial class Map {
        [XmlElement(Order=0, IsNullable=true)]
        public object Image { get; set; }        
        /// <remarks/>
        [XmlElement(ElementName="Location", Order = 1)]
        public Location Location1 {get; set; }        
        /// <remarks/>
        [XmlElement(ElementName = "Location", Order = 2)]
        public Location Location2 {get; set; }
    }
