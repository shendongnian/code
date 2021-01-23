    public class Root
    {
    	public Area Area { get; set; }
    }
    public class Area
    {
    	[XmlElement("id")]
    	public string Id { get; set; }
    	[XmlElement("type")]
    	public string Type { get; set; }
    	[XmlElement("size")]
    	public Coordinate Size { get; set; }
    	[XmlElement("position")]
    	public Coordinate Position { get; set; }
    	[XmlElement("rotation")]
    	public Coordinate Rotation { get; set; }
    	[XmlElement("zones")]
    	public List<Zone> Zones { get; set; }
    }
    public class Zone
    {
    	[XmlElement("id")]
    	public string Id { get; set; }
    	[XmlElement("type")]
    	public string Type { get; set; }
    	[XmlElement("size")]
    	public Coordinate Size { get; set; }
    	[XmlElement("position")]
    	public Coordinate Position { get; set; }
    	[XmlElement("rotation")]
    	public Coordinate Rotation { get; set; }
    }
    public class Coordinate
    {
    	[XmlElement("x")]
    	public float X { get; set; }
    	[XmlElement("y")]
    	public float Y { get; set; }
    	[XmlElement("z")]
    	public float Z { get; set; }
    }
