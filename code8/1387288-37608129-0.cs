    public class Polygons
    {
        [XmlElement("Polygon")]
        public List<Polygon> Polygon { get; set; }
    }
    
    public class Polygon
    {
        [XmlArrayItem]
        public Point2D[] Points { get; set; }
    }
    public class Point2D
    {
        [XmlAttribute]
        public int X { get; set; }
        [XmlAttribute]
        public int Y { get; set; }
    }
