	[XmlRoot(ElementName = "PROPERTIES")]
	public class Properties
	{
		[XmlElement(ElementName = "DATASOURCE")]
		public string Datasource { get; set; }
		[XmlElement(ElementName = "DATETIME")]
		public string Datetime { get; set; }
	}
	[XmlRoot(ElementName = "SOURCEDID")]
	public class Sourcedid
	{
		[XmlElement(ElementName = "SOURCE")]
		public string Source { get; set; }
		[XmlElement(ElementName = "ID")]
		public string ID { get; set; }
	}
	[XmlRoot(ElementName = "USERID")]
	public class UserId
	{
		[XmlAttribute(AttributeName = "password")]
		public string Password { get; set; }
		[XmlText]
		public string Text { get; set; }
	}
	[XmlRoot(ElementName = "PI")]
	public class PI
	{
		[XmlElement(ElementName = "FAMILY")]
		public string Family { get; set; }
		[XmlElement(ElementName = "GIVEN")]
		public string Given { get; set; }
		[XmlElement(ElementName = "EMAIL")]
		public string Email { get; set; }
	}
	[XmlRoot(ElementName = "NAME")]
	public class Name
	{
		[XmlElement(ElementName = "FN")]
		public string FN { get; set; }
		[XmlElement(ElementName = "PI")]
		public PI PI { get; set; }
	}
	[XmlRoot(ElementName = "PERSON")]
	public class Person
	{
		[XmlElement(ElementName = "SOURCEDID")]
		public Sourcedid Sourcedid { get; set; }
		[XmlElement(ElementName = "USERID")]
		public UserId Userid { get; set; }
		[XmlElement(ElementName = "NAME")]
		public Name Name { get; set; }
		[XmlAttribute(AttributeName = "recstatus")]
		public string Recstatus { get; set; }
	}
	[XmlRoot(ElementName = "COMPANY")]
	public class Company
	{
		[XmlElement(ElementName = "PROPERTIES")]
		public Properties Properties { get; set; }
		[XmlElement(ElementName = "PERSON")]
		public Person Person { get; set; }
	}
