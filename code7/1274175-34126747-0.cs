	[XmlRoot(ElementName="Price")]
	public class Price {
		[XmlElement(ElementName="Type")]
		public string Type { get; set; }
		[XmlElement(ElementName="Value")]
		public string Value { get; set; }
		[XmlElement(ElementName="Qty")]
		public string Qty { get; set; }
	}
	[XmlRoot(ElementName="Pricing")]
	public class Pricing {
		[XmlElement(ElementName="Price")]
		public List<Price> Price { get; set; }
	}
	[XmlRoot(ElementName="Departure")]
	public class Departure {
		[XmlElement(ElementName="Date")]
		public string Date { get; set; }
		[XmlElement(ElementName="Pricing")]
		public Pricing Pricing { get; set; }
	}
	[XmlRoot(ElementName="Availability")]
	public class Availability {
		[XmlElement(ElementName="Departure")]
		public List<Departure> Departure { get; set; }
	}
	[XmlRoot(ElementName="Cproducts")]
	public class Cproducts {
		[XmlElement(ElementName="Availability")]
		public Availability Availability { get; set; }
	}
	
