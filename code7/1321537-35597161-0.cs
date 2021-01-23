	[XmlRoot(ElementName="Table")]
	public class Table {
		[XmlElement(ElementName="CITY")]
		public string CITY { get; set; }
		[XmlElement(ElementName="STATE")]
		public string STATE { get; set; }
		[XmlElement(ElementName="ZIP")]
		public string ZIP { get; set; }
		[XmlElement(ElementName="AREA_CODE")]
		public string AREA_CODE { get; set; }
		[XmlElement(ElementName="TIME_ZONE")]
		public string TIME_ZONE { get; set; }
	}
	[XmlRoot(ElementName="NewDataSet")]
	public class NewDataSet {
		[XmlElement(ElementName="Table")]
		public Table Table { get; set; }
		[XmlAttribute(AttributeName="xmlns")]
		public string Xmlns { get; set; }
	}
