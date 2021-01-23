    [XmlType("level")]
    public class Level
    {
    	[XmlAttribute("name")]
    	public string Name { get; set; }
    	[XmlAttribute("complete")]
    	public string Complete { get; set; }
    	[XmlAttribute("stars")]
    	public string Stars { get; set; }
    	[XmlAttribute("firstMisson")]
    	public string FirstMisson { get; set; }
    	[XmlAttribute("secondMission")]
    	public string SecondMission { get; set; }
    	[XmlAttribute("thridMission")]
    	public string ThridMission { get; set; }
    }
    
    [XmlType("location")]
    public class Location
    {
    	[XmlElement("level")]
    	public Level Level { get; set; }
    	[XmlAttribute("id")]
    	public string Id { get; set; }
    }
