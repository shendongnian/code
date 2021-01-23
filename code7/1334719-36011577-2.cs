	public class OrderXML
	{
		[XmlElement("GROUP")]
		public Group[] GroupList { get; set; }
	}
	public class Group
	{
		[XmlElement(ElementName = "SELLER", Type = typeof(Seller))]
		public Seller[] Sellers { get; set; }
	}
