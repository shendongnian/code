    using System.Xml.Serialization;
    
    //was [SerializeAs(Name = "trackingrequest")]
    [XmlRoot("trackingrequest")]
    public class DpdTrackingRequest
    {
    	//was [SerializeAs(Name = "user")]
    	[XmlElement("user")]
    	public string User { get; set; }
    
    	//was [SerializeAs(Name = "password")]
    	[XmlElement("password")]
    	public string Password { get; set; }
    
    	//was [SerializeAs(Name = "trackingnumbers")]
    	//from IList to List
    	[XmlArray("trackingnumbers")]
    	[XmlArrayItem("trackingnumber")]
    	public List<DpdTrackingNumber> TrackingNumbers { get; set; }
    }
    
    public class DpdTrackingNumber
    {
    	[XmlText]
    	public string Value { get; set; }
    }
