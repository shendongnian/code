	// Define other methods and classes here
	[XmlRoot(ElementName = "Container")]
	public class Container {
		[XmlArray("Items", IsNullable = false)]
		[XmlArrayItem("Item")]
		public List<DerivedItem> Items { get; set; }
		
	}
	
	public class DerivedItem
	{
		[XmlAttribute("SomeField")]
		public string SomeField {get;set;}
		
		[XmlAttribute("OtherField")]
		public string OtherField {get;set;}
		
		public bool OtherFieldSpecified {get;set;}
	}
