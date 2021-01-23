	[Serializable, XmlRoot(ElementName = "IndexRoot", Namespace = "http://tempuri/2012/1.0")]
	public class IndexRootV10 : IndexRoot { }
	[Serializable, XmlRoot(ElementName = "IndexRoot", Namespace = "http://tempuri/2012/2.0")]
	public class IndexRootV20 : IndexRoot { }
	public class IndexRoot
	{
	    [XmlAttribute("Code")]
	    public string Code { get; set; }
	    [XmlElement(ElementName = "Code")]
	    public string Code { get; set; }
	}
