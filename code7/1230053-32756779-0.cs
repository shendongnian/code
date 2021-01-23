    [XmlType(AnonymousType = true, Namespace = "http://itaintworking.com/test/")]
    [XmlRoot(Namespace = "http://itaintworking.com/test/", IsNullable = false)]
    public class Clients
    {
    	[XmlElement(Namespace="")]
    	public string clientName { get; set; }
    	[XmlElement(Namespace = "")]
    	public addressDetails addressDetails { get; set; }
    }
