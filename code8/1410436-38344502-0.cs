	[XmlRoot(ElementName = "nodes")]
	public class Nodes
	{
		[XmlElement(ElementName = "node1")]
		public string node1 { get; set; }
		[XmlElement(ElementName = "node2")]
		public string node2 { get; set; }
		[XmlElement(ElementName = "node3")] 
		public string node3 { get; set; }
		[XmlArray("crsa")]
		[XmlArrayItem("crsa")]
		public Crsa[] crsa { get; set; }
		[XmlElement(ElementName = "node4")]
		public string node4 { get; set; }
	}
	
