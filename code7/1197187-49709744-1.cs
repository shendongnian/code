    [XmlRoot(ElementName = "RootType", Namespace = "http://my.custom.namespace.com")]
	public sealed class Root
	{
		[XmlElement("description")]
		public string Description { get; set; }
		[XmlElement("values")]
		public Value[] Values { get; set; }
	}
	
	public sealed class Value
	{
		[XmlElement("field")]
		public string Field { get; set; }
		[XmlElement("value", IsNullable = true)]
		public ValueProperty ValueProperty { get; set; }
	}
	[XmlInclude(typeof(CustomDouble))]
	[XmlRoot(Namespace = "http://my.custom.namespace.com")]
	public class ValueProperty
	{
		[XmlText]
		public string Value { get; set; }
	}
	[XmlType(TypeName = "double", Namespace = "http://www.w3.org/2001/XMLSchema")]
	public class CustomDouble : ValueProperty
	{
	}
